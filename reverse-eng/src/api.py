import flask
from flask import request, json, jsonify
import os

import requests

import download
import deepfake_detection_test
import connect_cache

app = flask.Flask(__name__)
app.config["DEBUG"] = False

@app.route('/', methods=['POST'])
def home():

    image_path = ""
    model_path = "0_32000_model_31_70-23.pickle"

    print(requests.json)

    if 'image_path' in request.json:
        image_path = request.json['image_path']


    if 'model_path' in request.json and request.json['model_path'] != "":
        model_path = request.json['model_path']

        if (model_path != "0_32000_model_31_70-23.pickle" and
            model_path != "0_32000_model_29.pickle" and 
            model_path != "0_64000_model_30.pickle"
           ):
            print("Modelo no encontrado")
            return {"Error": "El modelo no se encuentra disponible"}, 400

    download.downloadImage(image_path)

    path = "/home/reverse/data_test/0/image.jpg"
    # Vemos si está en la cache
    cache_result = connect_cache.get(path, 'reverse')

    if cache_result != '':
         return {"result": [{"0": cache_result}]}, 200

    result = deepfake_detection_test.detect(model_path)

    #print(result['result'][0]['0'])
    connect_cache.send(path, result['result'][0]['0'], 'reverse')

    return result, 200

if __name__ == "__main__":
    app.run(debug=True, host='0.0.0.0', port=int(os.environ.get("PORT", 8080)))
