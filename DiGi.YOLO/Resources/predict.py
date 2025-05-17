from pathlib import Path
from ultralytics import YOLO
import os
import glob

basePath = os.path.join("runs", "detect")
maxNumber = -1
modelPath = None

# Find the latest model path
for root, directories, files in os.walk(basePath):
    for directory in directories:
        if directory.startswith("train"):
            numberString = directory[5:]
            if numberString:
                number = int(numberString)
                if number > maxNumber:
                    maxNumber = number
                    modelPath = os.path.join(root, directory, "weights", "best.pt")

# Load your trained YOLO model
model = YOLO(modelPath)

# Define the folder with test images
imageDirectory = "images/test/"

# Get list of all image files (you can adjust extensions as needed)
imagePaths = glob.glob(os.path.join(imageDirectory, "*.jpg")) + \
              glob.glob(os.path.join(imageDirectory, "*.jpeg")) + \
              glob.glob(os.path.join(imageDirectory, "*.png"))

resultsPath = os.path.join(os.getcwd(), "results.txt")

if os.path.isfile(resultsPath):
    os.remove(resultsPath)

# Run inference on each image
for imagePath in imagePaths:
    print(f"Processing: {imagePath}")
    results = model(source=imagePath, show=False, conf=0.1, save=False)
    
    fileName = os.path.splitext(os.path.basename(imagePath))[0]

    values = []
    
    for result in results:
        for box in result.boxes:
            x, y, width, height = box.xyxy.Item().tolist()
            confidence = box.conf.item()
            labelIndex = int(box.cls.item())
            values.append(f"{fileName}\t{labelIndex}\t{x}\t{y}\t{width}\t{height}\t{confidence}\n")
    
    with open(resultsPath, "a") as file:
        for value in values:
            file.write(value)