import flask
from flask import request, json, jsonify
import connect_cache 
import video_clasification 
import download
import os

app = flask.Flask(__name__)
app.config["DEBUG"] = True

@app.route('/', methods=['POST'])
def home():

    video_path = ""


    if 'video_path' in request.json:
        video_path = request.json['video_path']

    name = video_path[video_path.find('=')+1:len(video_path)]

    ok = download.download_youtube(video_path, name)

    if ok < 0:
        return {"Error": "Ha habido algún problema al descargar el vídeo"}, 400

    path = "/home/kerasio/videos/" + name + ".mp4"

    # Vemos si está en la cache
    cache_result, cache_perFake, cache_perReal = connect_cache.get(path, 'kerasio')

    if cache_result != '':
         return {"result": [{"0": cache_result}], "perFake":cache_perFake, "perReal":cache_perReal}, 200

    result, perFake = video_clasification.detect(path)
    perReal = 100.0-perFake

    connect_cache.send(path, result[0]['0'], 'kerasio', perFake, perReal)

    return {"result":result, "perFake":perFake, "perReal":perReal}, 200

if __name__ == "__main__":
    app.run(debug=True, host='0.0.0.0', port=int(os.environ.get("PORT", 8083)))
