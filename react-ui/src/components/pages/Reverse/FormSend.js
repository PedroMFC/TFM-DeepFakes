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
    "reverse"
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
        <Button buttonStyle='btn--outline'
                buttonSize='btn--mobile' type='submit'>
          Comprobar
        </Button>
      </form>
    </div>
  );
};

export default FormSend;
