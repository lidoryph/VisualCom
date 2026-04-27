import requests
from requests.auth import HTTPBasicAuth
import os
import datetime

def ping_server(url: str) -> tuple[int, str]:

    try:
        r = requests.get(url)
    except requests.exceptions.ConnectionError:
        print("Couldn't get a hold of the server.")
        return (1, "")

    return(r.status_code, r.text)

def get_projects(url:str, user:str) -> tuple[int, str]:
    url = url + "/project/get/"
    basic = HTTPBasicAuth(user, user)


    try:
        r = requests.get(url, auth=basic)
    except requests.exceptions.ConnectionError:
        print("Couldn't get a hold of the server.")
        return (1, "")
    except requests.exceptions.InvalidSchema:
        print("Couldn't get a hold of the server.")
        return (1, "")
    
    return (r.status_code, r.text)

def new_project(url: str, name: str, type: str, user: str) -> tuple[int, str]:
    url = url + "/project/new/" + name + "/" + type
    basic = HTTPBasicAuth(user, user)
    try:
        r = requests.get(url, auth=basic)
    except requests.exceptions.ConnectionError:
        print("Couldn't get a hold of the server.")
        return (0, "")

    return (r.status_code, r.text)

def load_project(url: str, name: str, user:str) -> tuple[int, str]:
    url = url + "/project/get/" + name
    basic = HTTPBasicAuth(user, user)
    try:
        r = requests.get(url, auth=basic)
    except requests.exceptions.ConnectionError:
        return(1, "Couldn't get a hold of the server")
    
    return(r.status_code, r.text)

def delete_project(url: str, project: str, user:str) -> tuple[int, str]:
    url = url + "/project/delete/supersure/yes/" + project
    basic = HTTPBasicAuth(user, user)

    try:
        r = requests.get(url, auth=basic)
    except requests.exceptions.ConnectionError:
        print("Couldn't get a hold of the server.")
        return 1, ""
    
    return (r.status_code, r.text)

#ask for user
def get_images(url: str, name: str) -> tuple[int, str]:
    url = url + "/image/get/" + name + "/"

    try:
        r = requests.get(url)
    except requests.exceptions.ConnectionError:
        return(1, "Couldn't get a hold of the server.")

    return(r.status_code, r.text)

#ask for user
def new_image(url: str, filepath: str, project: str) -> tuple[int, str]:
    file = open(filepath, "+br")
    fileextension = os.path.basename(filepath).split(".")[-1]
    filename = str(str(datetime.datetime.now()) + "." + fileextension).replace(":", "-").replace(" ", "H")
    print(filename)
    url = url + "/image/new/" + project + "/" + filename
    files = {"file": (filepath, file, "image/" + fileextension)}
    
    print(url)
    try:
        r = requests.put(url, files=files)
    except requests.exceptions.ConnectionError:
        print("Couldn't get a hold of the server.")
        return (1, "")

    return (r.status_code, r.text)

#ask for user
def load_image(url:str, filepath:str, project: str) -> tuple[int, str]:
    url = url + "/image/load/" + project + "/" + filepath
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

#ask for user
def delete_image(url: str, project: str, filename: str, user: str) -> tuple[int, str]:
    url = url + "/image/del/" + project + "/" + filename

    basic = HTTPBasicAuth(user, user)

    try:
        r = requests.get(url, auth=basic)
    except requests.exceptions.ConnectionError:
        print("Couldn't get a hold of the server.")
        return 1, ""

    return r.status_code, r.text

#ask for user
#hacer y en server
def block_image(url: str, filename: str, project: str) -> tuple[int, str]:
    return 1, ""

def get_classes(url: str, name: str) -> tuple[int, str]:
    url = url + "/classes/" + name + "/get/"

    try:
        r = requests.get(url)
    except requests.exceptions.ConnectionError:
        return(1, "Couldn't get a hold of the server.")

    return(r.status_code, r.text)

#ask for user
def new_class(url: str, name: str, classname: str, color: str) -> tuple[int, str]:
    url = url + "/classes/" + name + "/new/" + classname + "/" + color

    try:
        r = requests.get(url)
    except requests.exceptions.ConnectionError:
        return(1, "Couldn't get a hold of the server.")

    return(r.status_code, r.text)

#ask for user
#hacer y en server
def delete_class(url: str, name: str, classname: str) -> tuple[int, str]:
    return(1, "")

def get_versions(url: str, name: str) -> tuple[int, str]:
    url = url + "/version/" + name + "/get/"

    try:
        r = requests.get(url)
    except requests.exceptions.ConnectionError:
        return(1, "Couldn't get a hold of the server.")
    
    return(r.status_code, r.text)

#ask for user
def new_version(url: str, name: str, version: str) -> tuple[int, str]:
    url = url + "/version/" + name + "/new/" + version

    try:
        r = requests.get(url)
    except requests.exceptions.ConnectionError:
        return(1, "Couldn't get a hold of the server.")
    
    return(r.status_code, r.text)

#ask for user
def delete_version(url: str, name: str, version: str) -> tuple[int, str]:
    url = url + "/version/" + name + "/del/" + version

    try:
        r = requests.get(url)
    except requests.exceptions.ConnectionError:
        return(1, "Couldn't get a hold of the server")
    
    return(r.status_code, r.text)

#hacer y en server
def train_model(url: str, name: str, version) -> tuple[int, str]:
    return(1, "")

#hacer y en server
def new_label(url: str, name: str, image:str, botleft: str, topright: str) -> tuple[int, str]:
    return(1, "")

#hacer y en server
def delete_label(url: str, name: str, image: str, botleft:str, topright: str) -> tuple[int, str]:
    return(1, "")

#hacer y en server
def login(url: str, username: str, password: str) -> tuple[int, str]:
    return(1, "")