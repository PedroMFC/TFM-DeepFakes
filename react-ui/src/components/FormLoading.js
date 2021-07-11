import React from 'react';
import './Form.css';

const FormLoading = () => {
  return (
    <>
      <div
        className='home__hero-section'
      >
        <div className='container'>
          <div className='row home__hero-row' style={{true: 'flex', flexDirection: 'row' }} >
              <div className='home__hero-text-wrapper'>
                <h1 className='heading dark'>Procesando... Puede tardar un rato</h1>
                <div className='home__hero-img-wrapper'>
                  <img src='img/loading.svg' className='home__hero-img' />
                </div>
            </div>
          </div>
        </div>
      </div>
    </>
  );

};

export default FormLoading;
