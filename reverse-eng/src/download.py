import requests
import os

def downloadImage(url):
    r = requests.get(url)

    if not os.path.exists('/home/reverse/data_test'): #Añadido por si se usa en local poder descargar varias
        os.mkdir('/home/reverse/data_test')
        os.mkdir('/home/reverse/data_test/0')
        
    with open("/home/reverse/data_test/0/image.jpg", "wb") as f:
        f.write(r.content)