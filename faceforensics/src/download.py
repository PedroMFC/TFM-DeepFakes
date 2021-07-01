from pytube import YouTube

def download_youtube(link, name):
    try: 
        # object creation using YouTube
        # which was imported in the beginning 
        yt = YouTube(link) 
    except: 
        print("Connection Error") #to handle exception 
    
    # get the video with the extension and
    # resolution passed in the get() function 
    d_video = yt.streams.first()
    try: 
        # downloading the video 
        d_video.download("/home/faceforensics/videos", filename=name) 
    except: 
        print("Ha habido algún error")
        return -1 

    print('Vídeo descargado') 
    return 0
