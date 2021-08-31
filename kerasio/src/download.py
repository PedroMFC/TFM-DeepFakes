from pytube import YouTube

def download_youtube(link, name):
    try: 
        # Creción del objeto usando Youtube
        yt = YouTube(link) 
        d_video = yt.streams.first()

        d_video.download("/home/kerasio/videos", filename=name+".mp4") 

    except: 
        print('Ha habido algún error al descargar el vídeo')
        return -1 

    print('Vídeo descargado correctamente')
    return 0
