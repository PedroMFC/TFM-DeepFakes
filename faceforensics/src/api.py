import flask
from flask import request, json, jsonify
import detect 
import download
import os
import connect_cache

app = flask.Flask(__name__)
app.config["DEBUG"] = True

@app.route('/', methods=['POST'])
def home():

    video_path = ""
    model_path = ""
    start_frame = 0
    end_frame = None
    full = 0

    if 'video_path' in request.json:
        video_path = request.json['video_path']

    if 'model_path' in request.json and request.json['model_path'] != "":
        model_path = request.json['model_path']

        if model_path != "ffpp_c40.pth" and model_path != "ffpp_c23.pth":
            return {"Error": "El modelo no se encuentra disponible"}, 400
    else:
        model_path = "ffpp_c40.pth"

    if 'start_frame' in request.json:
        start_frame = request.json['start_frame']

        if not isinstance(start_frame, int) or not start_frame >= 0:
            return {"Error": "El parámetro 'start_frame' frame no es correcto"}, 400

    if 'end_frame' in request.json:
        end_frame = request.json['end_frame']

        if not isinstance(end_frame, int) or not end_frame >= 0:
            return {"Error": "El parámetro 'end_frame' frame no es correcto"}, 400

    if 'full' in request.json:
        full = request.json['full']

    name = video_path[video_path.find('=')+1:len(video_path)]

    ok = download.download_youtube(video_path, name)

    if ok < 0:
        return {"Error": "Ha habido algún problema al descargar el vídeo"}, 400

    path = "/home/faceforensics/videos/" + name + ".mp4"

    # Vemos si está en la cache
    cache_result = connect_cache.get(path, 'faceforensics')

    if cache_result != '':
         return {"result": [{"0": cache_result}]}, 200

    result = detect.test_full_image_network(path, "../pretrained_model/" + model_path, "", start_frame, end_frame, False)


    if not full: # Si queremos saber el resultado como media
        isFake = 0
        isReal = 0

        for frame in result:
            for key in frame.keys():
                if frame.get(key) == 'fake':
                    isFake += 1
                else:
                    isReal += 1

        # print('Is fake:' + str(isFake) + "/ Is real: " + str(isReal))
        finalLabel = 'fake' if isFake > isReal else 'real'
        result = [{'0': finalLabel}]
        # print(result)

    connect_cache.send(path, result[0]['0'], 'faceforensics')

    return {"result":result}, 200

if __name__ == "__main__":
    app.run(debug=True, host='0.0.0.0', port=int(os.environ.get("PORT", 8080)))
