from pathlib import Path
from ultralytics import YOLO
from utils import GetDirectory, GetModelPath
import os
import glob

modelPath = GetModelPath(useDefault=False)
if not modelPath:
    print("Could not find model.")
    exit()

print(f"Model path: {modelPath}")

# Load your trained YOLO model
model = YOLO(modelPath)

# Define the folder with test images
imageDirectory = os.path.join("images", "predict")

# Get list of all image files (you can adjust extensions as needed)
imagePaths = glob.glob(os.path.join(imageDirectory, "*.jpg")) + \
              glob.glob(os.path.join(imageDirectory, "*.jpeg")) + \
              glob.glob(os.path.join(imageDirectory, "*.png"))

# Run inference on each image
for imagePath in imagePaths:
    print(f"Processing: {imagePath}")
    results = model(source=imagePath, show=False, conf=0.1, save=False)
    
    fileName = os.path.splitext(os.path.basename(imagePath))[0]

    values = []
    
    for result in results:
        
        os.makedirs(result.save_dir, exist_ok=True)
        
        resultsPath = os.path.join(result.save_dir, "results.bbrf")
        
        if not result.boxes or len(result.boxes) < 1:
            values.append(f"{fileName}\n")
            continue
        
        for box in result.boxes:
            x, y, width, height = box.xyxy[0].tolist()
            confidence = box.conf.item()
            labelIndex = int(box.cls.item())
            values.append(f"{fileName}\t{labelIndex}\t{x}\t{y}\t{width}\t{height}\t{confidence}\n")
    
        with open(resultsPath, "a") as file:
            for value in values:
                file.write(value)