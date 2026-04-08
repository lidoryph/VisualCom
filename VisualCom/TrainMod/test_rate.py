import requests
import time

while True:
    r = requests.get("http://127.0.0.1:4541/project/get/")
    print(r.status_code, r.text)
    if r.status_code != 200:
        time.sleep(30)