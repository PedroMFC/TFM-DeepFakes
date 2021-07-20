import flask
from flask import request, json, jsonify
import os

from flask.wrappers import Request

import firebase_admin
from firebase_admin import credentials
from firebase_admin import firestore
import firestore

app = flask.Flask(__name__)
app.config["DEBUG"] = True

@app.route('/results/<sha>/<service>', methods=['GET'])
def get_entry(sha, service):

    result = firestore.get(sha, service)

    return {"result":result}, 200

@app.route('/results', methods=['PUT'])
def add_entry():

    sha = ""
    result = ""
    service = ""

    if 'sha' in request.json and request.json['sha'] != "":
        sha = request.json['sha']
    else:
        return {"Error": "La petición es incorrecta. Falta el id"}, 400

    if 'result' in request.json and request.json['result'] != "":
        result = request.json['result']
    else:
        return {"Error": "La petición es incorrecta. Falta el resultado"}, 400

    if 'service' in request.json and request.json['service'] != "":
        service = request.json['service']
    else:
        return {"Error": "La petición es incorrecta. Falta el servicio"}, 400

    firestore.save(sha, service, result)

    return {"result":"Creado correctamente"}, 201

@app.route('/requests/<user>', methods=['GET'])
def get_user(user):

    result = firestore.getUser(user)

    return {"timestamps":result}, 200

@app.route('/requests/<user>', methods=['POST'])
def save_user(user):

    timestamps = None

    if 'timestamps' in request.json:
        timestamps = request.json['timestamps']
    else:
        return {"Error": "La petición es incorrecta. Faltan los tiempos"}, 400

    firestore.saveUser(user, timestamps)

    return {"result":"Añadida correctamante"}, 201

if __name__ == "__main__":
    app.run(debug=True, host='0.0.0.0', port=int(os.environ.get("PORT", 8084)))


