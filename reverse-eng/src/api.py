import flask
from flask import request, json, jsonify
import os

import download
import deepfake_detection_test

app = flask.Flask(__name__)
app.config["DEBUG"] = True

@app.route('/', methods=['POST'])
def home():

    image_path = ""

    if 'image_path' in request.json:
        image_path = request.json['image_path']

    if 'model_path' in request.json:
        model_path = request.json['model_path']

        if (model_path != '0_32000_model_31_70-23.pickle' and
            model_path != '0_32000_model_29.pickle' and 
            model_path != '0_64000_model_30.pickle'
           ):

            return {"Error": "El modelo no se encuentra disponible"}, 400

    download.downloadImage(image_path)

    print('DESCARGADO')

    result = deepfake_detection_test.detect(model_path)

    return result, 200

if __name__ == "__main__":
    app.run(debug=True, host='0.0.0.0', port=int(os.environ.get("PORT", 8080)))
