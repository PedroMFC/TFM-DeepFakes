import React from 'react';
import './Form.css';

const FormError = () => {
  return (
    <>
      <div
        className='home__hero-section'
      >
        <div className='container'>
          <div className='row home__hero-row' style={{true: 'flex', flexDirection: 'row' }} >
              <div className='home__hero-text-wrapper'>
                <h1 className='heading dark'>Parece que ha ocurrido algún error</h1>
                <div className='home__hero-img-wrapper'>
                  <img src='img/error.svg' className='home__hero-img' />
                </div>
            </div>
          </div>
        </div>
      </div>
    </>
  );
};

export default FormError;
