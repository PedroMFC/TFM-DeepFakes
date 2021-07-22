import React from 'react';
import validateInfo from './validateInfo';
import useForm from './useForm';
import '../../Form.css';
import { Button } from '../../Button'

const FormSend = ({ submitForm , setFinalResult }) => {
  const { handleChange, handleSubmit, values, errors } = useForm(
    submitForm,
    setFinalResult,
    validateInfo,
    "kerasioimg"
  );

  return (
    <div className='form-content-right'>
      <form onSubmit={handleSubmit} className='form' noValidate>
        <h1>
          Introduce la URL de la imagen
        </h1>
        <div className='form-inputs'>
          <label className='form-label'>URL de la imagen</label>
          <input
            className='form-input'
            type='text'
            name='image_path'
            placeholder='https://...'
            value={values.image_path}
            onChange={handleChange}
          />
          {errors.image_path && <p>{errors.image_path}</p>}
        </div>
        <div className='form-inputs'>
          <label className='form-label'>URL del modelo</label>
          <input
            className='form-input'
            type='text'
            name='model_path'
            placeholder='https://...'
            value={values.model_path}
            onChange={handleChange}
          />
          {errors.model_path && <p>{errors.model_path}</p>}
        </div>
        <div className='form-inputs'>
          <label className='form-label'>Tamaño de entrada del modelo</label>
          <input
            className='form-input'
            type='text'
            name='image_size'
            placeholder='299'
            value={values.image_size}
            onChange={handleChange}
          />
          {errors.image_size && <p>{errors.image_size}</p>}
        </div>
        <div className='form-inputs'>
          <label className='form-label'>¿User Lime? Introducir "S" par sí </label>
          <input
            className='form-input'
            type='text'
            name='lime'
            value={values.lime}
            placeholder='S'
            onChange={handleChange}
          />
        </div>
        <Button buttonStyle='btn--outline'
                buttonSize='btn--mobile' type='submit'>
          Comprobar
        </Button>

        <span></span>

        { values.file != '' ? (
          <label style={{margin: "15px", color:"#ffffff"}}>Almacenado en: {values.file} </label>    
        ): []}
    
      </form>
    </div>
  );
};

export default FormSend;
