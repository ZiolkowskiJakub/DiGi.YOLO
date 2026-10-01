import argparse
import json
import os
from ultralytics import YOLO
from utils import FileSHA256, GetModelPath

# Trains a YOLO detector headlessly. The start weights are always a local file - a checkpoint (.pt) to continue
# from or a base checkpoint such as yolo26x.pt, or an architecture definition (.yaml) for random initialisation -
# so a run is offline and reproducible; nothing is downloaded implicitly by name.
#
# A second mode continues an interrupted run: --resume <last.pt> restores every argument from the checkpoint's
# train_args instead of the command line, so nothing but --device may be overridden and the epoch ceiling is
# fixed by the checkpoint. A finished checkpoint has nothing to resume and is refused.
#
# Output contract read by DiGi.YOLO Modify.Train (one value per line, invariant formatting):
#   Start model: <path>
#   Start model SHA256: <hex>
#   Start model kind: checkpoint | definition | resume
#   Start model train_args: <json>          (checkpoints and resume)
#   Resume epoch: <1-based epoch the run enters>   (resume only; repeated in the success block)
#   Resume epochs: <ceiling restored from the checkpoint>   (resume only; repeated in the success block)
#   ... ultralytics training output ...
#   Weights: <path of best.pt>
#   Bytes: <size of best.pt>
#   SHA256: <hex of best.pt>
#   AMP: True | False                       (the precision actually used; the AMP check falls back to False when it fails)
#   Resume epoch: <1-based epoch the run entered>   (resume only)
#   Resume epochs: <ceiling>                        (resume only)
# Exit code 0 only when best.pt was written.
#
# The resume values are printed before training and again in the success block because the runner keeps only the
# tail of a long run's output, so a value printed only at the start would not survive to be read back.


def Fresh(args):
    modelPath = args.model if args.model else GetModelPath(useDefault=True)
    if not modelPath or not os.path.isfile(modelPath):
        print(f"Could not find model: {modelPath}")
        exit(1)

    extension = os.path.splitext(modelPath)[1].lower()
    if extension == ".pt":
        kind = "checkpoint"
    elif extension in (".yaml", ".yml"):
        kind = "definition"
    else:
        print(f"Model is neither a .pt checkpoint nor a .yaml definition: {modelPath}")
        exit(1)

    if not args.data or not os.path.isfile(args.data):
        print(f"Could not find data: {args.data}")
        exit(1)

    modelPath = os.path.abspath(modelPath)

    print(f"Start model: {modelPath}")
    print(f"Start model SHA256: {FileSHA256(modelPath)}")
    print(f"Start model kind: {kind}")

    if kind == "checkpoint":
        # train_args of a checkpoint is the only record of how it was trained (for model.pt the only surviving record
        # of train8); its "model" entry is printed as written, it is not a path on this machine
        import torch

        checkpoint = torch.load(modelPath, map_location="cpu", weights_only=False)
        trainArgs = checkpoint.get("train_args") if isinstance(checkpoint, dict) else None
        print(f"Start model train_args: {json.dumps(trainArgs, default=str, sort_keys=True)}")

    trainArguments = {
        "data": os.path.abspath(args.data),
        "epochs": args.epochs,
        "patience": args.patience,
        "imgsz": args.imgsz,
        "batch": args.batch,
        "seed": args.seed,
        "amp": args.amp,
    }

    if args.project:
        trainArguments["project"] = os.path.abspath(args.project)

    if args.name:
        trainArguments["name"] = args.name

    if args.device:
        trainArguments["device"] = args.device

    model = YOLO(modelPath)
    model.train(**trainArguments)

    Report(model)


def Resume(args):
    resumePath = args.resume
    if not resumePath or not os.path.isfile(resumePath):
        print(f"Could not find resume checkpoint: {resumePath}")
        exit(1)

    if os.path.splitext(resumePath)[1].lower() != ".pt":
        print(f"Resume weights are not a .pt checkpoint: {resumePath}")
        exit(1)

    resumePath = os.path.abspath(resumePath)

    try:
        import torch

        checkpoint = torch.load(resumePath, map_location="cpu", weights_only=False)
    except Exception as exception:
        print(f"Could not read resume checkpoint: {exception}")
        exit(1)

    if not isinstance(checkpoint, dict):
        print(f"Resume checkpoint is not a dictionary: {resumePath}")
        exit(1)

    trainArgs = checkpoint.get("train_args")
    if not isinstance(trainArgs, dict):
        trainArgs = {}

    epochs = trainArgs.get("epochs")
    epoch = checkpoint.get("epoch")

    # ultralytics stores the 0-based index of the last epoch completed and drops the optimizer state (stamping -1)
    # once the run finished; either makes the checkpoint not resumable. Passing resume=True on a finished checkpoint
    # does not fail - ultralytics only warns and starts a fresh run - so the guard has to be here.
    if not isinstance(epoch, int) or epoch < 0 or checkpoint.get("optimizer") is None:
        print(f"Nothing to resume: training to {epochs} epochs is finished")
        exit(1)

    data = trainArgs.get("data")
    if not data or not os.path.isfile(data):
        print(f"Could not find data: {data}")
        exit(1)

    print(f"Start model: {resumePath}")
    print(f"Start model SHA256: {FileSHA256(resumePath)}")
    print(f"Start model kind: resume")

    # the epoch the run enters, 1-based: the stored index plus the completed epoch it names plus the next one
    resumeEpoch = epoch + 2
    print(f"Resume epoch: {resumeEpoch}")
    print(f"Resume epochs: {epochs}")
    print(f"Start model train_args: {json.dumps(trainArgs, default=str, sort_keys=True)}")

    # only device may be overridden on resume; ultralytics restores every other argument from the checkpoint and
    # warns about (and ignores) any it does not allow, so data, epochs, project and name are deliberately not passed
    trainArguments = {"resume": True}
    if args.device:
        trainArguments["device"] = args.device

    model = YOLO(resumePath)
    model.train(**trainArguments)

    Report(model, resumeEpoch, epochs)


def Report(model, resumeEpoch=None, resumeEpochs=None):
    trainer = model.trainer
    weightsPath = str(trainer.best) if trainer is not None and trainer.best else None
    if not weightsPath or not os.path.isfile(weightsPath):
        print(f"Training did not produce weights: {weightsPath}")
        exit(1)

    print(f"Weights: {os.path.abspath(weightsPath)}")
    print(f"Bytes: {os.path.getsize(weightsPath)}")
    print(f"SHA256: {FileSHA256(weightsPath)}")
    print(f"AMP: {bool(trainer.amp)}")

    if resumeEpoch is not None:
        print(f"Resume epoch: {resumeEpoch}")
        print(f"Resume epochs: {resumeEpochs}")


def main():
    parser = argparse.ArgumentParser(description="YOLO Training Script")
    parser.add_argument("--model", type=str, default=None, help="Start weights: a local .pt checkpoint or a .yaml architecture definition")
    parser.add_argument("--resume", type=str, default=None, help="Path of a weights\\last.pt of an interrupted run to continue")
    parser.add_argument("--data", type=str, default="conf.yaml", help="Path to the dataset configuration file (conf.yaml)")
    parser.add_argument("--epochs", type=int, default=150, help="Upper bound of training epochs")
    parser.add_argument("--patience", type=int, default=50, help="Epochs without validation improvement before early stopping")
    parser.add_argument("--imgsz", type=int, default=640, help="Square training image size")
    parser.add_argument("--batch", type=int, default=16, help="Training batch size")
    parser.add_argument("--seed", type=int, default=0, help="Random seed")
    parser.add_argument("--project", type=str, default=None, help="Directory the run directory is created in")
    parser.add_argument("--name", type=str, default=None, help="Name of the run directory")
    parser.add_argument("--device", type=str, default=None, help="Device, e.g. 0, 0,1 or cpu")
    parser.add_argument("--amp", action=argparse.BooleanOptionalAction, default=True, help="Automatic mixed precision")

    args = parser.parse_args()

    if args.model and args.resume:
        print("--model and --resume are mutually exclusive")
        exit(1)

    if args.resume:
        Resume(args)
    else:
        Fresh(args)


if __name__ == "__main__":
    main()
