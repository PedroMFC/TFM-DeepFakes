from pytube import YouTube

def download_youtube(link, name):
    try: 
        # Creción del objeto usando Youtube
        yt = YouTube(link) 
        d_video = yt.streams.filter(adaptive=True).first()

        d_video.download("/home/faceforensics/videos", filename=name + ".mp4") 
        #d_video.download("/app/videos", filename=name + ".mp4") 

    except: 
        print('Ha habido algún error al descargar el vídeo')
        return -1 

    print('Vídeo descargado correctamente')
    return 0
