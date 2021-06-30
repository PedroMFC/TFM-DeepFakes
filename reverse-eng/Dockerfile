FROM python:3.6-slim
LABEL maintainer="Pedro Flores <pedro_23_96@hotmail.com>" 
LABEL version="0.0.1"

RUN apt-get update 

COPY requirements.txt .
RUN python -m pip install -r requirements.txt
# Creamos un usuario no root que ejecute la aplicación
RUN useradd -m reverse
USER reverse

# Establecemos directorio de trabajo
WORKDIR /app

COPY ./src /app

# Comando a ejecutar
CMD exec gunicorn --bind :$PORT --workers 1 --threads 8 --timeout 0 api:app