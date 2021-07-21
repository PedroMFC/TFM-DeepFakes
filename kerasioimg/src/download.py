from pytube import YouTube
from google.cloud import storage

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

def upload_blob(bucket_name, source_file_name, destination_blob_name):
    """Uploads a file to the bucket."""

    storage_client = storage.Client()

    bucket = storage_client.bucket(bucket_name)
    blob = bucket.blob(destination_blob_name)

    blob.upload_from_filename(source_file_name)

    print(
        "File {} uploaded to {}.".format(
            source_file_name, destination_blob_name
        )
    )