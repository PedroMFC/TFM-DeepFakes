# TFM-DeepFakes

Repositorio para el Trabajo Fin de Máster sobre DeepFakes.

## Dockerfile

En el [Dockerfile](./Dockerfile) se instalan las dependencias necesarias para ejecutar la implementación para detectar DeepFakes llevada a cabo por [HongguLiu](https://github.com/HongguLiu/Deepfake-Detection). Para crear el contenedor y ejecutarlo se recomienda usar las órdenes del gestor de tareas [Task](https://taskfile.dev/#/) que se encuentran en el [Taskfile.yml](./Taskfile.yml). 

```
 > task docker-build
 > task docker-run
```

Tras ello, se obtendría un vídeo como el disponible [aquí](./output).