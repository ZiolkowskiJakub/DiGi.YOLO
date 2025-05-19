import os

def GetDirectory(directory, directoryName):
    
    if not directory or not directoryName:
        return None
        
    length = len(directoryName)
    result = None
    maxNumber = -1
    for root, directories, files in os.walk(directory):
        for directory in directories:
            if directory.startswith(directoryName):
                numberString = directory[length:]
                if numberString:
                    number = int(numberString)
                    if number > maxNumber:
                        maxNumber = number
                        result = os.path.join(root, directory)
                        
    return result
    
    
def GetModelPath(useDefault):
    
    trainDirectory = GetDirectory(os.path.join("runs", "detect"), "train")
    if not trainDirectory:
        return None
        
    result = os.path.join(trainDirectory, "weights", "best.pt")
    if os.path.isfile(result):
        return result 
        
    if useDefault:
        return "yolov8x.yaml"       

    return None