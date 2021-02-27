# Ocupa 3.38GB y funciona
FROM python:3.6-slim
LABEL maintainer="Pedro Flores <pedro_23_96@hotmail.com>" 
LABEL version="0.2.0"

# Actualizamos e instalamos algunas librerías necesarias
RUN apt-get update \
    && apt-get install -y libgl1-mesa-dev build-essential libglib2.0-0 qt5-default 

# Tenemos que instalar cmake aparte para dblib
COPY requirements.txt .
RUN python -m pip install cmake==3.18.4.post1 \ 
    && python -m pip install -r requirements.txt

# Creamos un usuario no root que ejecute la aplicación
RUN useradd -m faceforensics
USER faceforensics

# Establecemos directorio de trabajo
WORKDIR /app

# Comando a ejecutar
CMD [ "sh", "-c", "python ./src/detect_from_video.py --video_path ./videos/$VIDEO --model_path ./pretrained_model/$MODEL -o ./output"]