from pytube import YouTube

def download_youtube(link, name):
    try: 
        # Creción del objeto usando Youtube
        yt = YouTube(link) 
        d_video = yt.streams.first()

        d_video.download("/home/kerasio/videos", filename=name) 

    except: 
        print("Ha habido algún error")
        return -1 

    print('Vídeo descargado') 
    return 0
