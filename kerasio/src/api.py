import flask
from flask import request, json, jsonify
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

    result = video_clasification.detect("/home/kerasio/videos/" + name + ".mp4")

    return {"result":result}, 200

if __name__ == "__main__":
    app.run(debug=True, host='0.0.0.0', port=int(os.environ.get("PORT", 8083)))