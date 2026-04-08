from common_variables import allmodels, latest
import os
import urllib.request
import requests
from urllib.parse import urlparse
import urllib.error

def download_model(modelname: str) -> int:

    url = "https://github.com/ultralytics/assets/releases/download/" + latest.tag_name

    if modelname not in allmodels:
        print("error")
        return -1
    
    model = allmodels[modelname]
    url = f"{url}/{model}"
    model = os.path.join("models", model)

    os.makedirs("models", exist_ok=True)

    response = urllib.request.urlopen(url)
    try:
        f = open(model, "xb")
    except FileExistsError:
        return -2
    
    f.write(response.read())
    
    return 0


def pull_model(modelurl: str) -> int:
    
    if not (modelurl.__contains__("https://")):
        modelurl = "https://" + modelurl

    os.makedirs("models", exist_ok=True)
    
    p = urlparse(modelurl)
    modelpath = p.path.rsplit("/", 1)[-1]
    
    modelpath = os.path.join("models", modelpath)

    try:
        response = urllib.request.urlopen(modelurl)
    except urllib.error.URLError:
        return -3

    try:
        f = open(modelpath, "xb")
    except FileExistsError:
        return -2
    
    f.write(response.read())

    return 0