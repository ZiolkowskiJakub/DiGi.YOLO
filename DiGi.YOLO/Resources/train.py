from ultralytics import YOLO
from utils import GetModelPath
import os

def main():
    
    modelPath = GetModelPath(useDefault=True)
    
    if not modelPath:
        print("Could not find model.")
        exit()
        
    print(f"Used model: {modelPath}")
    
    model = YOLO(modelPath)
    model.train(data="conf.yaml", imgsz=640, epochs=100)

if __name__ == "__main__":
    main()