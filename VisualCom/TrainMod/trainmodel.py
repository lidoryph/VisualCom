from common_variables import AllModelsPath
import os
from ultralytics import YOLO
from ultralytics.utils import LOGGER

def train(datapath: str, epochs: int, imgsz: int, device: str, modelname: str, seed:int, path: str, progress_callback=None):
    ModelsInDir = os.listdir(AllModelsPath)

    modelpath = os.path.join(AllModelsPath, modelname)

    if not (os.path.exists(os.path.join(modelpath))):
        return {"error": -1}
    
    model = YOLO(modelpath)
    LOGGER.setLevel(30)

    if not (os.path.exists(datapath)):
        return {"error": -2}

    if progress_callback is not None:
        model.add_callback(
            "on_train_epoch_end",
            lambda t: progress_callback(t.epoch + 1, epochs)
        )
    
    if device != "cpu":
        int(device)

    results = model.train(data=datapath, epochs=epochs, imgsz=imgsz, save=True, verbose=False, seed=seed, device=device, project=path)
    return {"status": 100.0}