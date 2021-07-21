import { useState, useEffect } from 'react';

const useForm = (callback, callback2, validate, path) => {
  const [values, setValues] = useState({
    video_path: '',
  });
  const [errors, setErrors] = useState({});
  const [isSubmitting, setIsSubmitting] = useState(false);

  const handleChange = e => {
    const { name, value } = e.target;
    setValues({
      ...values,
      [name]: value
    });
  };

  const handleSubmit = e => {
    e.preventDefault();
    
    setErrors(validate(values));
    if (Object.keys(errors).length === 0 ){
      callback2("")
      fetch("https://api-utoehvsqvq-ew.a.run.app/" + path, {
              "method": "POST",
              "headers": {
                  "content-type": "application/json",
                  "accept": "application/json"
              },
              "body": JSON.stringify({
                image_path: values.image_path,
              })
          })
          .then(response => response.json())
          .then(response => {
              console.log(response)

              if(response.result != undefined){
                if (response.result[0]["0"] === "real" ){
                  console.log("Pues es real")
                  callback2("real")
                } else{
                  callback2("fake")
                }
              } else {
                if (response.Error == "Ha superado el máximo de intentos"){
                  callback2("wait")
                } else{
                  callback2("error")
                }
              }
          })
          .catch(err => {
              console.log(err.response);
              callback2("error")
          });

      setIsSubmitting(true);
    }
  };

  useEffect(
    () => {
      if (Object.keys(errors).length === 0 && isSubmitting) {
        callback();
      }
    },
    [errors]
  );

  return { handleChange, handleSubmit, values, errors };
};

export default useForm;