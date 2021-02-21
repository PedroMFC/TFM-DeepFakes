FROM python:3.6 
LABEL maintainer="Pedro Flores <pedro_23_96@hotmail.com>" 
LABEL version="0.1.0"

# Actualizamos e instalamos algunas librerías necesarias
RUN apt-get update \
    && apt-get install -y libgl1-mesa-dev

# Insatalamos requerimientos para ejecutar la aplicación
RUN python -m pip install cmake 
RUN python -m pip install dlib==19.18.0
RUN python -m pip install opencv-python
RUN python -m pip install tqdm
RUN python -m pip install torch
RUN python -m pip install torchvision
# RUN python -m pip install numpy==1.17.3
RUN python -m pip install pillow>=6.2.2

# Creamos un usuario no root que ejecute la aplicación
RUN useradd -m faceforensics
USER faceforensics

# Establecemos directorio de trabajo
WORKDIR /app

# Comando a ejecutar
CMD [ "sh", "-c", "python ./src/detect_from_video.py --video_path ./videos/$VIDEO --model_path ./pretrained_model/$MODEL -o ./output"]