import requests
import os
import datetime

def ping_server(url: str) -> tuple[int, str]:

    try:
        r = requests.get(url)
    except requests.exceptions.ConnectionError:
        print("Couldn't get a hold of the server.")
        return (1, "")

    return(r.status_code, r.text)

def get_projects(url:str) -> tuple[int, str]:
    url = url + "/project/get/"

    try:
        r = requests.get(url)
    except requests.exceptions.ConnectionError:
        print("Couldn't get a hold of the server.")
        return (1, "")
    except requests.exceptions.InvalidSchema:
        print("Couldn't get a hold of the server.")
        return (1, "")
    
    return (r.status_code, r.text)

#hacer
def load_projects(url: str, name: str) -> tuple[int, str]:
    return(1, "")

def new_project(url: str, name: str, type: str) -> tuple[int, str]:
    url = url + "/project/new/" + name + "/" + type
    try:
        r = requests.get(url)
    except requests.exceptions.ConnectionError:
        print("Couldn't get a hold of the server.")
        return (1, "")

    return (r.status_code, r.text)
  
#hacer y en server
def load_project(url: str, name: str) -> tuple[int, str]:
    return 1, ""

def delete_project(url: str, project: str) -> tuple[int, str]:
    url = url + "/project/delete/supersure/yes/" + project

    try:
        r = requests.get(url)
    except requests.exceptions.ConnectionError:
        print("Couldn't get a hold of the server.")
        return 1, ""
    
    return (r.status_code, r.text)

def upload_image(url: str, filepath: str, project: str) -> tuple[int, str]:
    file = open(filepath, "+br")
    fileextension = os.path.basename(filepath).split(".")[-1]
    filename = str(str(datetime.datetime.now()) + "." + fileextension).replace(":", "-").replace(" ", "H")
    print(filename)
    
    files = {"file": (filepath, file, "image/" + fileextension)}
    url = url + "/add/" + project + "/" + filename
    print(url)
    try:
        r = requests.put(url, files=files)
    except requests.exceptions.ConnectionError:
        print("Couldn't get a hold of the server.")
        return (1, "")

    return (r.status_code, r.text)

def download_image(url:str, filepath:str, project: str) -> tuple[int, str]:
    url = url + "/get/" + project + "/" + filepath
    file = open(filepath, "+bw")
    
    try:
        r = requests.get(url, stream=True)
    except requests.exceptions.ConnectionError:
        print("Couldn't get a hold of the server.")
        return (1, "")
    
    if r.status_code == 404:
        return (r.status_code, r.text)

    for chunk in r.iter_content(chunk_size=8192):
        if chunk:
            file.write(chunk)

    return (r.status_code, r.text)

def remove_image(url: str, filename: str, project: str) -> tuple[int, str]:
    url = url + "/del/" + project + "/" + filename

    try:
        r = requests.get(url)
    except requests.exceptions.ConnectionError:
        print("Couldn't get a hold of the server.")
        return 1, ""

    return r.status_code, r.text

#hacer
def block_image(url: str, filename: str, project: str) -> tuple[int, str]:
    return 1, ""

#hacer y en server
def get_classes(url: str, name: str) -> tuple[int, str]:
    return(1, "")

#hacer y en server
def add_class(url: str, name: str, classname: str, color: str) -> tuple[int, str]:
    return(1, "")

#hacer y en server
def erase_class(url: str, name: str, classname: str) -> tuple[int, str]:
    return(1, "")

#hacer y en server
def get_versions(url: str, name: str) -> tuple[int, str]:
    return(1, "")

#hacer y en server
def add_version(url: str, name: str, version: str) -> tuple[int, str]:
    return(1, "")

#hacer y en server
def erase_version(url: str, name: str) -> tuple[int, str]:
    return(1, "")

#hacer y en server
def train_model(url: str, name: str, version) -> tuple[int, str]:
    return(1, "")

#hacer y en server
def add_label(url: str, name: str, image:str, botleft: str, topright: str) -> tuple[int, str]:
    return(1, "")

#hacer y en server
def erase_label(url: str, name: str, image: str, botleft:str, topright: str) -> tuple[int, str]:
    return(1, "")

#hacer y en server
def login(url: str, username: str, password: str) -> tuple[int, str]:
    return(1, "")