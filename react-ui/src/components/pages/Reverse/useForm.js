import { useState, useEffect } from 'react';
import CheckRequests from '../../requestsLogic.js'

const useForm = (callback, callback2, validate, path) => {
  const [values, setValues] = useState({
    image_path: '',
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

  const handleSubmit = async(e) => {
    e.preventDefault();

    setErrors(validate(values));

    console.log(Object.keys(errors).length)
    if (Object.keys(errors).length === 0 ){
      var aceptado = false
      const result = await CheckRequests()

      if (result > 0){
        aceptado = true
      }

      if (aceptado){
        callback(true);
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
                
                if (response.result[0]["0"] === "real" ){
                  callback2("real")
                } else{
                  callback2("fake")
                }

            })
            .catch(err => {
                console.log(err);
                callback2("error")
            });

      } else{
      
        callback2("wait")
      }
    }
    
    setIsSubmitting(true);

  };

  useEffect(
    () => {
      if (Object.keys(errors).length === 0 && isSubmitting) {
        callback(true);
      }
    },
    [errors]
  );

  return { handleChange, handleSubmit, values, errors };
};

export default useForm;
