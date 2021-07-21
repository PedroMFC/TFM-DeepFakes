import flask
from flask import request, json, jsonify
import connect_cache 
import image_clasification 
import os

app = flask.Flask(__name__)
app.config["DEBUG"] = True

os.environ['GOOGLE_APPLICATION_CREDENTIALS'] = 'key.json'

@app.route('/', methods=['POST'])
def home():

    image_path = ""
    model_path = ""
    image_size = 299
    lime = 0

    if 'image_path' in request.json and request.json['image_path'] != "":
        image_path = request.json['image_path']
    else:
        return {"Error": "No se ha proporcionado URL de la imagen"}, 400

    if 'model_path' in request.json and request.json['model_path'] != "":
        model_path = request.json['model_path']
    else:
        return {"Error": "No se ha proporcionado URL del modelo"}, 400

    if 'image_size' in request.json and request.json['image_size'] > 0:
        image_size = request.json['image_size']

    if 'lime' in request.json:
        lime = request.json['lime']

    result, fileHash = image_clasification.detect(image_path, model_path, image_size, lime)


    return {"result":[{"0": result}], "file":fileHash}, 200

if __name__ == "__main__":
    app.run(debug=True, host='0.0.0.0', port=int(os.environ.get("PORT", 8083)))
