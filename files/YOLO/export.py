import argparse
import hashlib
import os
import shutil
from ultralytics import YOLO
from utils import GetDirectory, GetModelPath

# Exports the frozen checkpoint to ONNX so the detector can be scored in process, without an
# interpreter. This is a one-off preparation step: it still needs ultralytics, and it must be run
# with the version that wrote the checkpoint (8.3.130 - see requirements.txt), or the exported graph
# is not the frozen detector any more.
#
# opset 12 is the widest opset the runtimes in use accept without complaint. dynamic is on so the
# exported graph takes any batch size; a static export pins the batch to one, and the C# runner then
# has to pad every partial batch to feed it.

parser = argparse.ArgumentParser(description="YOLO ONNX Export Script")
parser.add_argument("--model", type=str, default=None, help="Path to trained YOLO model file")
parser.add_argument("--output", type=str, default=None, help="Path to write the exported ONNX model to")
parser.add_argument("--imgsz", type=int, default=640, help="Square input size the graph is exported at")
parser.add_argument("--opset", type=int, default=12, help="ONNX opset version")
parser.add_argument("--static", action="store_true", help="Export with fixed axes instead of a dynamic batch")

args = parser.parse_args()

modelPath = args.model if args.model else GetModelPath(useDefault=True)
if not modelPath or not os.path.isfile(modelPath):
    print("Could not find model.")
    exit(1)

print(f"Model path: {modelPath}")
model = YOLO(modelPath)

exportedPath = model.export(format="onnx", imgsz=args.imgsz, opset=args.opset, dynamic=not args.static, simplify=True, half=False, nms=False)

if not exportedPath or not os.path.isfile(exportedPath):
    print("Export did not produce a file.")
    exit(1)

outputPath = args.output if args.output else exportedPath
if os.path.abspath(outputPath) != os.path.abspath(exportedPath):
    outputDir = os.path.dirname(os.path.abspath(outputPath))
    if outputDir:
        os.makedirs(outputDir, exist_ok=True)
    shutil.move(exportedPath, outputPath)

# The exported graph is as frozen as the checkpoint it came from, so it is recorded the same way -
# by a digest read off the artefact rather than by a note somebody kept up to date by hand.
digest = hashlib.sha256()
with open(outputPath, "rb") as file:
    for chunk in iter(lambda: file.read(1024 * 1024), b""):
        digest.update(chunk)

print(f"Exported: {outputPath}")
print(f"Bytes: {os.path.getsize(outputPath)}")
print(f"SHA256: {digest.hexdigest()}")
