import argparse
import json
import os

# Reports what a .pt checkpoint holds - the epoch it reached, whether it can still be resumed and how it was
# trained - without ultralytics, so a caller can name "epoch N of M" and refuse a finished checkpoint before
# starting a training process. torch.load is the only dependency; the raw epoch it reads is the 0-based index
# of the last epoch completed, exactly as ultralytics stores it, and the number work resumes at is that value
# plus two (the 1-based number of the epoch the resumed run enters).
#
# Output contract read by DiGi.YOLO Query.YOLOCheckpointInformation (one JSON line between two marker lines,
# the same shape check.py uses):
#   YOLO_CHECKPOINT_JSON_BEGIN
#   { "readable": ..., "epoch": ..., "epochs": ..., "finished": ..., "data": ..., "project": ...,
#     "name": ..., "best_fitness": ..., "train_args": ..., "messages": [...] }
#   YOLO_CHECKPOINT_JSON_END

parser = argparse.ArgumentParser(description="YOLO Checkpoint Information Script")
parser.add_argument("--model", type=str, required=True, help="Path to a .pt checkpoint")
args = parser.parse_args()


def AsInt(value):
    if isinstance(value, bool):
        return None

    if isinstance(value, int):
        return value

    if isinstance(value, float) and value.is_integer():
        return int(value)

    return None


def AsString(value):
    if value is None:
        return None

    return str(value)


result = {
    "readable": False,
    "epoch": None,
    "epochs": None,
    "finished": None,
    "data": None,
    "project": None,
    "name": None,
    "best_fitness": None,
    "train_args": None,
    "messages": []
}

modelPath = args.model
checkpoint = None

if not modelPath or not os.path.isfile(modelPath):
    result["messages"].append(f"Checkpoint file does not exist: {modelPath}")
else:
    try:
        import torch

        # weights_only is stated rather than inherited: torch 2.6 flipped torch.load's default to
        # weights_only=True, which refuses the ultralytics classes a checkpoint carries. The same
        # reasoning check.py records for its own probe.
        checkpoint = torch.load(modelPath, map_location="cpu", weights_only=False)
    except Exception as exception:
        result["messages"].append(f"Could not read checkpoint: {exception}")

    if isinstance(checkpoint, dict):
        result["readable"] = True

        epoch = AsInt(checkpoint.get("epoch"))
        result["epoch"] = epoch
        # ultralytics stores the 0-based epoch just completed in an unfinished checkpoint and stamps -1 once
        # the run is finished, alongside dropping the optimizer state; either makes the checkpoint not resumable
        result["finished"] = epoch is None or epoch < 0 or checkpoint.get("optimizer") is None

        bestFitness = checkpoint.get("best_fitness")
        if isinstance(bestFitness, (int, float)) and not isinstance(bestFitness, bool):
            result["best_fitness"] = float(bestFitness)

        trainArgs = checkpoint.get("train_args")
        if isinstance(trainArgs, dict):
            result["train_args"] = json.loads(json.dumps(trainArgs, default=str))
            result["epochs"] = AsInt(trainArgs.get("epochs"))
            result["data"] = AsString(trainArgs.get("data"))
            result["project"] = AsString(trainArgs.get("project"))
            result["name"] = AsString(trainArgs.get("name"))
    elif checkpoint is not None:
        result["messages"].append("Checkpoint is not a dictionary.")

# The stdout contract: the JSON payload sits between two marker lines, so a caller finds it without depending
# on what the interpreter or ultralytics print before it - a settings notice included. The C# side
# (Query/CheckJsonLine.cs) reads the first non-empty line between the markers; everything else is noise.
print("YOLO_CHECKPOINT_JSON_BEGIN")
print(json.dumps(result, default=str))
print("YOLO_CHECKPOINT_JSON_END")
