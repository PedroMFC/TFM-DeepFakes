import React from 'react';
import validate from './validateInfo';
import useForm from './useForm';
import { Button } from '../../Button'

// http://images.ctfassets.net/hrltx12pl8hq/7yQR5uJhwEkRfjwMFJ7bUK/dc52a0913e8ff8b5c276177890eb0129/offset_comp_772626-opt.jpg?fit=fill&w=800&h=300
const FormSend = ({ submitForm , setFinalResult }) => {
  const { handleChange, handleSubmit, values, errors } = useForm(
    submitForm,
    setFinalResult,
    validate,
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
