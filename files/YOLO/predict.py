import argparse
import glob
import os
from pathlib import Path
from ultralytics import YOLO
from utils import GetDirectory, GetModelPath

parser = argparse.ArgumentParser(description="YOLO Prediction Script")
parser.add_argument("--model", type=str, default=None, help="Path to trained YOLO model file")
parser.add_argument("--source", type=str, default=None, help="Path to input image file or directory")
parser.add_argument("--conf", type=float, default=0.1, help="Confidence threshold")
parser.add_argument("--output", type=str, default=None, help="Path to output bbrf results file")

args = parser.parse_args()

modelPath = args.model if args.model else GetModelPath(useDefault=True)
if not modelPath:
    print("Could not find model.")
    exit(1)

print(f"Model path: {modelPath}")
model = YOLO(modelPath)

sourcePath = args.source if args.source else os.path.join("YOLO", "input")
outputPath = args.output if args.output else os.path.join("YOLO", "output", "results.bbrf")

imagePaths = []
if os.path.isfile(sourcePath):
    imagePaths = [sourcePath]
elif os.path.isdir(sourcePath):
    imagePaths = glob.glob(os.path.join(sourcePath, "*.jpg")) + \
                 glob.glob(os.path.join(sourcePath, "*.jpeg")) + \
                 glob.glob(os.path.join(sourcePath, "*.png"))

values = []
for imagePath in imagePaths:
    print(f"Processing: {imagePath}")
    results = model(source=imagePath, show=False, conf=args.conf, save=False)
    fileName = os.path.splitext(os.path.basename(imagePath))[0]

    for result in results:
        if not result.boxes or len(result.boxes) < 1:
            values.append(f"{fileName}\n")
            continue

        for box in result.boxes:
            x1, y1, x2, y2 = box.xyxy[0].tolist()
            width = x2 - x1
            height = y2 - y1
            confidence = box.conf.item()
            labelIndex = int(box.cls.item())
            values.append(f"{fileName}\t{labelIndex}\t{x1}\t{y1}\t{width}\t{height}\t{confidence}\n")

if outputPath and values:
    outputDir = os.path.dirname(os.path.abspath(outputPath))
    if outputDir:
        os.makedirs(outputDir, exist_ok=True)
    with open(outputPath, "w") as file:
        for value in values:
            file.write(value)
