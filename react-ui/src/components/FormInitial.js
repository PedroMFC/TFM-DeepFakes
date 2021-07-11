import React from 'react';
import './Form.css';
import './HeroSection.css';

const FormInital = () => {
  return (
    <>
      <div
        className='home__hero-section'
      >
        <div className='container'>
          <div className='row home__hero-row' style={{true: 'flex', flexDirection: 'row' }} >
              <div className='home__hero-text-wrapper'>
                <h1 className='heading dark'>¿Será un DeepFake?</h1>
                <div className='home__hero-img-wrapper'>
                  <img src='img/question.svg' className='home__hero-img' />
                </div>
            </div>
          </div>
        </div>
      </div>
    </>
  );
};

export default FormInital;
