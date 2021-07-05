from pytube import YouTube

def download_youtube(link, name):
    try: 
        # Creción del objeto usando Youtube
        yt = YouTube(link) 
    except: 
        print("Connection Error") # Manejar la excepción
    
    # Obtener el vídeo con la extensión y resolución
    d_video = yt.streams.first()
    try: 
        # Descargar el vídeo
        d_video.download("/home/faceforensics/videos", filename=name) 
    except: 
        print("Ha habido algún error")
        return -1 

    print('Vídeo descargado') 
    return 0
