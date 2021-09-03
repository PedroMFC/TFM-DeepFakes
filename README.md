![Cloud Build](https://storage.googleapis.com/deepfakes-317408-badges/builds/tfm-deepfakes/branches/main.svg)

[![](./imgs/tryWeb.png)](https://reactui-utoehvsqvq-ew.a.run.app)

# TFM-DeepFakes

Repositorio para el Trabajo Fin de Máster sobre DeepFakes.

## Introducción

Despliegue en Google Cloud de un sistema de microservicios para la detección de *DeepFakes* utilizando diversos algoritmos para vídeos e imágenes. La división en directorio de cada uno de los microservicios es la siguiente:

* [API](./api) - Servicio que proporciona la API para la detección de DeepFakes.
* [FaceForensics](./faceforensics) - Servicio que proporciona la detección en videos usando el algoritmo [FaceForensics++](https://github.com/HongguLiu/Deepfake-Detection).
* [Reverse Engineering](./reverse-eng) - Servicio que proporciona la detección de rostros sintéticos en imágenes. Nos baso en la [esta implementación](https://github.com/vishal3477/Reverse_Engineering_GMs).
* [Keras vídeo](./kerasio) - Propuesta para la clasificación de vídeo con una red convolutiva y otra recurrente. [Video Classification with a CNN-RNN Architecture](https://keras.io/examples/vision/video_classification/)
* [Keras imágenes](./kerasioimg) - Servicio para clasificación de imágenes usando una red alojada en TensorFlowHub.

También se han desarrollado dos interfaces de usuario:
* [Web](./react-ui) - Interfaz web de usuario para la detección de DeepFakes accesible en [este enlace](https://reactui-utoehvsqvq-ew.a.run.app).
* [Plugin de FOCA](./pluginfoca) - Plugin para la aplicación [FOCA](https://github.com/ElevenPaths/FOCA), programa desarrollado por Telefónica.

A continuación, explicamos cómo ejecutar en local estos contenedores y poder probar los algoritmos.

## Ejecución de las órdenes

Se recomienda usar las órdenes del gestor de tareas [Task](https://taskfile.dev/#/) que se encuentran en el [Taskfile.yml](./Taskfile.yml), aunque no es obligatorio. Se aconseja cambiar el valor de las variables GCR_FF, GCR_RE y GCR_API con los nombres de los contenedores deseados. Las órdenes disponibles se pueden consultar mediante la orden:

```
 > task -l
```

## FaceForensics

Para la implementación del agloritmo **FaceForensics++** (detección de *DeepFakes* en vídeos) se usado la implementación disponible en el Repositorio de [HongguLiu](https://github.com/HongguLiu/Deepfake-Detection). El código modificado en nuestro repositorio se encuentra en la carpeta [faceforensics](./faceforensics). Para ejecutarlo en local utilizamos las órdenes:

```
 > task docker-build-ff # Construir el contenedor
 > task docker-run-ff   # Lanzar el contenedor 
 > task request-api-ff  # Realizar la petición
```

Para llamar al servicio desplegado en Google Cloud utilizamos:

```
 > task request-api-gcr-ff  # Realizar la petición
```

## Clasificación de vídeo con Keras

Para la clasificación de vídeo con una arquitectura CNN-RNN usamos la biblioteca Keras a partir del código disponible en [esta página](https://keras.io/examples/vision/video_classification/). El código modificado en nuestro repositorio se encuentra en la carpeta [kerasio](./kerasio). Para ejecutarlo en local utilizamos las órdenes:

```
 > task docker-build-kio # Construir el contenedor
 > task docker-run-kio   # Lanzar el contenedor 
 > task request-api-kio  # Realizar la petición
```

Para llamar al servicio desplegado en Google Cloud utilizamos:

```
 > task request-api-gcr-kio  # Realizar la petición
```

## Clasificación de imágenes con Keras

Para la clasificación de imágenes con Keras debemos de indicar un modelo preentreanado y subido a [TensorFlow Hub](https://www.tensorflow.org/hub?hl=es-419). Este modelo tiene que estar entrenado de tal modo que las clase *fake* sea clasificada como 1 para el correcto funcionamiento. El código modificado en nuestro repositorio se encuentra en la carpeta [kerasioimg](./kerasioimg). Para ejecutarlo en local utilizamos las órdenes:

```
 > docker-build-kio-img-cred # Construuir el contenedor de credenciales
 > task docker-build-kio-img # Construir el contenedor
 > task docker-run-kio-img   # Lanzar el contenedor 
 > task request-api-kio-img  # Realizar la petición
```

Para llamar al servicio desplegado en Google Cloud utilizamos:

```
 > task request-api-gcr-kio-img  # Realizar la petición
```

## Reverse Engineering

Para la implementación del agloritmo **Reverse Engineering Generative Modesl** (detección de *DeepFakes* en imágenes) se usado la implementación disponible en el Repositorio de [Reverse_Engineering_GMs](https://github.com/vishal3477/Reverse_Engineering_GMs). El código modificado en nuestro repositorio se encuentra en la carpeta [reverse-eng](./reverse-eng). Para ejecutarlo en local utilizamos las órdenes:

```
 > task docker-build-re # Construir el contenedor
 > task docker-run-re   # Lanzar el contenedor 
 > task request-api-re  # Realizar la petición
```

Para llamar al servicio desplegado en Google Cloud utilizamos:

```
 > task request-api-gcr-re  # Realizar la petición
```

 ## API de entrada

Para tener un único *endpoint*, se ha implementado una API que sea la que reciba las peticiones y las redirija al servicio correspondiente. Esta aplicación se ha implementado en Go y está disponible en la carpeta [api](./api). Para ejecutarlo en local utilizamos las órdenes

```
 > task docker-build-api       # Construir el contenedor
 > task docker-run-api         # Lanzar el contenedor 
 > task request-api-api-img    # Realizar la petición de prueba
 > task request-api-api-video  # Realizar la petición de prueba
```

Para llamar al servicio desplegado en Google Cloud utilizamos:

```
 > task request-api-api-gcr-img     # Realizar la petición de prueba
 > task request-api-api--gcr-video  # Realizar la petición de prueba
```

## Frontend

Con la finalidad de hace más fácil el uso del sistema se han creado dos interfaces de usuario diferentes. La primera de ellas se encutra en la carpeta [react-ui](./react-ui). Se trata de una **interfaz web desarrollada mediente React**. Se puede ejecutar localmente pero también se ha desplegado en la nube y el servicio está disponible en [esta dirección](https://reactui-utoehvsqvq-ew.a.run.app).

La segunda interfaz se ha creado como un plugin de [FOCA](https://github.com/ElevenPaths/FOCA), herramienta para encintrar metadatos e información oculta en documentos. En este caso, el código se encuentra en [pluginfoca](./pluginfoca). Para poder usarlo, hay que descargarse FOCA y añadir la librería [DeepFakes Analisis](./pluginfoca/FocaPluginExample/bin/Debug/DeepFakesAnalisis.dll). Notamos que es necesario incluir, en la carpeta de ejecución de FOCA, las librerías necesarias para el funcionamiento de la que nosostros hemos desarrollado y que se encuentran en la carpeta [bin/Debug](./pluginfoca/FocaPluginExample/bin/Debug).