import React from 'react';
import validate from './validateInfo';
import useForm from './useForm';
import { Button } from '../../Button'

const FormSend = ({ submitForm }) => {
  const { handleChange, handleSubmit, values, errors } = useForm(
    submitForm,
    validate
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
            name='video_path'
            placeholder='https://...'
            value={values.video_path}
            onChange={handleChange}
          />
          {errors.video_path && <p>{errors.video_path}</p>}
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
