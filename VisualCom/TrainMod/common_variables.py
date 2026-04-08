from github import Github 
import os

latest = Github().get_repo("ultralytics/assets").get_latest_release()

allmodels = {
        "YOLO26 Nano": "yolo26n.pt",
        "YOLO26 Small": "yolo26s.pt",
        "YOLO26 Medium": "yolo26m.pt",
        "YOLO26 Large": "yolo26l.pt",
        "YOLO26 Extra": "yolo26x.pt",
        "YOLO11 Medium": "yolo11m.pt",
        "YOLO11 Extra": "yolo11x.pt"
    }

AllModelsPath = os.path.join("models")