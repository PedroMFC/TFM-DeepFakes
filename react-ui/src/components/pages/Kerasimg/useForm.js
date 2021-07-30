import { useState, useEffect } from 'react';
import publicIp from "public-ip";

const useForm = (callback, callback2, validate, path) => {
  const [values, setValues] = useState({
    image_path: '',
    model_path: '',
    image_size: '',
    lime: '',
    file:'',
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
    if (Object.keys(errors).length === 0 ){
      setIsSubmitting(true)
      callback2("")
      setValues({
        ...values,
        file: ''
      });
      var limeAux = values.lime == "S" ? 1: 0
      var ip = await publicIp.v4()
      console.log(ip)
      fetch("https://api-utoehvsqvq-ew.a.run.app/" + path, {
              "method": "POST",
              "headers": {
                  "content-type": "application/json",
                  "accept": "application/json"
              },
              "body": JSON.stringify({
                image_path: values.image_path,
                model_path: values.model_path,
                image_size: parseInt(values.image_size),
                lime: limeAux ,
                ip: ip,
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

                if (response.file != undefined){
                  setValues({
                    ...values,
                    file: response.file
                  });
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