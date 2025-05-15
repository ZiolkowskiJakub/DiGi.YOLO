from ultralytics import YOLO
import os

def main():
    
    modelPath_Temp = "runs/detect/train/weights/best.pt"
    
    modelPath = "yolov8x.yaml"
    if os.path.exists(modelPath_Temp):
        modelPath = modelPath_Temp
        
    print(f"Used model: {modelPath}")
    
    model = YOLO(modelPath)
    model.train(data="conf.yaml", imgsz=640, epochs=10)

if __name__ == "__main__":
    main()