import os

def GetDirectory(directory, directoryName):
    if not directory or not directoryName or not os.path.exists(directory):
        return None

    length = len(directoryName)
    matchingDirs = []
    for root, directories, files in os.walk(directory):
        for d in directories:
            if d == directoryName or (d.startswith(directoryName) and d[length:].isdigit()):
                matchingDirs.append(os.path.join(root, d))

    if not matchingDirs:
        return None

    matchingDirs.sort(key=os.path.getmtime, reverse=True)
    return matchingDirs[0]


def GetModelPath(useDefault):
    defaultPath = os.path.join("YOLO", "models", "model.pt")
    if os.path.isfile(defaultPath):
        return defaultPath

    trainDirectory = GetDirectory(os.path.join("runs", "detect"), "train")
    if trainDirectory:
        result = os.path.join(trainDirectory, "weights", "best.pt")
        if os.path.isfile(result):
            return result

    if useDefault:
        return defaultPath

    return None
