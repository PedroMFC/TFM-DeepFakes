FROM python:3.6-slim
LABEL maintainer="Pedro Flores <pedro_23_96@hotmail.com>" 
LABEL version="0.0.1"

COPY src/serviceAccountKey.json /app/credentials/serviceAccountKey.json

