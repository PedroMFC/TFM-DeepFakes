export default function validateInfo(values) {
  let errors = {};

  if (!values.image_path.trim()) {
    errors.image_path = 'Es obligatorio introducir una dirección';
  }

  return errors;
}
