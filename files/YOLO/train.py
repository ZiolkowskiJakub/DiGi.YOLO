import argparse
import json
import os
from ultralytics import YOLO
from utils import FileSHA256, GetModelPath

# Trains a YOLO detector headlessly. The start weights are always a local file - a checkpoint (.pt) to continue
# from or a base checkpoint such as yolo26x.pt, or an architecture definition (.yaml) for random initialisation -
# so a run is offline and reproducible; nothing is downloaded implicitly by name.
#
# Output contract read by DiGi.YOLO Modify.Train (one value per line, invariant formatting):
#   Start model: <path>
#   Start model SHA256: <hex>
#   Start model kind: checkpoint | definition
#   Start model train_args: <json>          (checkpoints only)
#   ... ultralytics training output ...
#   Weights: <path of best.pt>
#   Bytes: <size of best.pt>
#   SHA256: <hex of best.pt>
#   AMP: True | False                       (the precision actually used; the AMP check falls back to False when it fails)
# Exit code 0 only when best.pt was written.


def main():
    parser = argparse.ArgumentParser(description="YOLO Training Script")
    parser.add_argument("--model", type=str, default=None, help="Start weights: a local .pt checkpoint or a .yaml architecture definition")
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

    trainer = model.trainer
    weightsPath = str(trainer.best) if trainer is not None and trainer.best else None
    if not weightsPath or not os.path.isfile(weightsPath):
        print(f"Training did not produce weights: {weightsPath}")
        exit(1)

    print(f"Weights: {os.path.abspath(weightsPath)}")
    print(f"Bytes: {os.path.getsize(weightsPath)}")
    print(f"SHA256: {FileSHA256(weightsPath)}")
    print(f"AMP: {bool(trainer.amp)}")


if __name__ == "__main__":
    main()
