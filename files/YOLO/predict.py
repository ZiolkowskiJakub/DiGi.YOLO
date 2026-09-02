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
parser.add_argument("--batch", type=int, default=32, help="Inference batch size")

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

batchSize = max(1, args.batch) if args.batch else 32

if outputPath and imagePaths:
    outputDir = os.path.dirname(os.path.abspath(outputPath))
    if outputDir:
        os.makedirs(outputDir, exist_ok=True)
    with open(outputPath, "w", encoding="utf-8") as file:
        for i in range(0, len(imagePaths), batchSize):
            chunk = imagePaths[i:i + batchSize]
            results = model(source=chunk, batch=len(chunk), show=False, conf=args.conf, save=False, verbose=False)
            for imagePath, result in zip(chunk, results):
                fileName = os.path.splitext(os.path.basename(imagePath))[0]
                if not result.boxes or len(result.boxes) < 1:
                    file.write(f"{fileName}\n")
                    continue

                for box in result.boxes:
                    x1, y1, x2, y2 = box.xyxy[0].tolist()
                    width = x2 - x1
                    height = y2 - y1
                    confidence = box.conf.item()
                    labelIndex = int(box.cls.item())
                    file.write(f"{fileName}\t{labelIndex}\t{x1}\t{y1}\t{width}\t{height}\t{confidence}\n")
            file.flush()
