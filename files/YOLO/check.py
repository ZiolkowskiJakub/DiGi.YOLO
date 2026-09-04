import argparse
import json
import os
import sys

parser = argparse.ArgumentParser(description="YOLO Preflight Check Script")
parser.add_argument("--model", type=str, default=None, help="Path to model file")
args = parser.parse_args()

messages = []
warnings = []
python_version = sys.version.split()[0]
torch_version = None
cuda_available = None
ultralytics_version = None
model_ultralytics_version = None

try:
    import torch
    torch_version = str(torch.__version__)
    cuda_available = bool(torch.cuda.is_available())
except Exception as exception:
    messages.append(f"torch import failed: {exception}")

try:
    import ultralytics
    ultralytics_version = str(ultralytics.__version__)
except Exception as exception:
    messages.append(f"ultralytics import failed: {exception}")

if args.model:
    model_path = args.model
    if not os.path.exists(model_path):
        messages.append(f"Model file does not exist: {model_path}")
    else:
        try:
            import torch
            # weights_only is stated rather than inherited: torch 2.6 flipped torch.load's default to
            # weights_only=True, which refuses the ultralytics classes a checkpoint carries. The probe's
            # correctness must not rest on ultralytics patching torch.load as a side effect of an import
            # ordered above this line, so it names its own intent here.
            checkpoint = torch.load(model_path, map_location="cpu", weights_only=False)
            if isinstance(checkpoint, dict) and "version" in checkpoint:
                model_ultralytics_version = str(checkpoint["version"])
        except Exception as exception:
            # A present model whose header cannot be parsed is diagnostic, not a refusal: runnable is about
            # whether this machine can score, and the version string only tells which ultralytics wrote the
            # weights. A missing model, interpreter or torch is what stops a run.
            warnings.append(f"Could not read model metadata: {exception}")

runnable = ultralytics_version is not None and torch_version is not None and len(messages) == 0

result = {
    "runnable": runnable,
    "python_version": python_version,
    "ultralytics_version": ultralytics_version,
    "torch_version": torch_version,
    "cuda_available": cuda_available,
    "model_ultralytics_version": model_ultralytics_version,
    "messages": messages,
    "warnings": warnings
}

print(json.dumps(result))
