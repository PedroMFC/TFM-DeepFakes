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

    download.downloadImage(image_path)

    print('DESCARGADO')

    result = deepfake_detection_test.detect()

    return result

if __name__ == "__main__":
    app.run(debug=True, host='0.0.0.0', port=int(os.environ.get("PORT", 8080)))
