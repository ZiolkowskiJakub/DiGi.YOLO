from ultralytics import YOLO
import os

def main():
    
    basePath = os.path.join("runs", "detect")
    maxNumber = -1
    modelPath = None

    for root, directories, files in os.walk(basePath):
        for directory in directories:
            if directory.startswith("train"):
                numberString = directory[5:]
                if numberString:
                    number = int(numberString)
                    if number > maxNumber:
                        maxNumber = number
                        modelPath = os.path.join(root, directory, "weights", "best.pt")
    
    if not modelPath or modelPath.strip() == "" or not os.path.exists(modelPath):
        modelPath = "yolov8x.yaml"
        
    print(f"Used model: {modelPath}")
    
    model = YOLO(modelPath)
    model.train(data="conf.yaml", imgsz=640, epochs=10)

if __name__ == "__main__":
    main()