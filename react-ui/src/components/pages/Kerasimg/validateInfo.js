export default function validateInfo(values) {
  let errors = {};

  if (!values.image_path.trim()) {
    errors.video_image_pathpath = 'Es obligatorio introducir una dirección';
  }

  if (!values.model_path.trim()) {
    errors.model_path = 'Es obligatorio introducir un modelo';
  }

  if (!values.image_size.trim()) {
    errors.image_size = 'Es obligatorio introducir el tamaño de entrada';
  }

  return errors;
}
