# TFM-DeepFakes

Repositorio para el Trabajo Fin de Máster sobre DeepFakes.

## Introducción

Despliegue en Google Cloud de un sistema de microservicios para la detección de *DeepFakes* utilizando diversos algoritmos para vídeos e imágenes. A continuación, explicamos cómo ejecutar en local estos contenedores y poder probar los algoritmos.

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