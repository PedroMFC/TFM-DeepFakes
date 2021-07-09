export default function validateInfo(values) {
  let errors = {};

  if (!values.video_path.trim()) {
    errors.video_path = 'Es obligatorio introducir una dirección';
  }

  return errors;
}
