from pathlib import Path
from ultralytics import YOLO
import os
import glob

# Load your trained YOLO model
model = YOLO("runs/detect/train/weights/best.pt")

# Define the folder with test images
image_folder = "images/test/"

# Get list of all image files (you can adjust extensions as needed)
image_files = glob.glob(os.path.join(image_folder, "*.jpg")) + \
              glob.glob(os.path.join(image_folder, "*.jpeg")) + \
              glob.glob(os.path.join(image_folder, "*.png"))

# Run inference on each image
for image_path in image_files:
    print(f"Processing: {image_path}")
    results = model(source=image_path, show=False, conf=0.4, save=True)
    print("Bounding boxes of all detected objects in [tagIndex x y width height confidence] format:")
    
    values = []
    
    for result in results:
        for box in result.boxes:
            x, y, width, height = box.xyxy[0].tolist()
            confidence = box.conf.tolist()[0]
            tagIndex = int(box.cls.tolist()[0])
            values.append(f"{tagIndex} {x} {y} {width} {height} {confidence}\n")
    
    path = Path(image_path)
    parts = list(path.parts)
    parts[parts.index("images")] = "labels"
    new_path = Path(*parts).with_suffix(".txt")

    new_path.parent.mkdir(parents=True, exist_ok=True)
    
    if new_path.is_file():
        new_path.unlink()
    
    with open(new_path, "a") as file:
        for value in values:
            print(value)
            file.write(value)   
