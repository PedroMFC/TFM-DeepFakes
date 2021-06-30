import requests
import os

def downloadImage(url):
    r = requests.get(url)

    os.mkdir('/home/reverse/data_test')
    os.mkdir('/home/reverse/data_test/0')
    with open("/home/reverse/data_test/0/image.jpg", "wb") as f:
        f.write(r.content)