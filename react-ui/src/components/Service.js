import React from 'react';
import { Button } from './Button';
import './Service.css';
import { GiCrystalize } from 'react-icons/gi';
import { IconContext } from 'react-icons/lib';
import { Link } from 'react-router-dom';
import { BsFillCameraVideoFill, BsCamera, BsCameraVideo } from "react-icons/bs";

function Service() {
  return (
    <IconContext.Provider value={{ color: '#fff', size: 64 }}>
      <div className='pricing__section'>
        <div className='pricing__wrapper'>
          <h1 className='pricing__heading'>Servicios disponibles</h1>
          <div className='pricing__container'>
            <Link to='/faceforensics' className='pricing__container-card'>
              <div className='pricing__container-cardInfo'>
                <div className='icon'>
                  <BsFillCameraVideoFill />
                </div>
                <h3>FaceForensics++</h3>
                <ul className='pricing__container-features'>
                  <li>Análisis de vídeo</li>
                </ul>
                <Button buttonSize='btn--wide' buttonColor='primary'>
                Probar
                </Button>
              </div>
            </Link>
            <Link to='/reverse' className='pricing__container-card'>
              <div className='pricing__container-cardInfo'>
                <div className='icon'>
                  <BsCamera />
                </div>
                <h3>Reverse Engineering</h3>
                <ul className='pricing__container-features'>
                  <li>Análsis de imágenes</li>

                </ul>
                <Button buttonSize='btn--wide' buttonColor='blue'>
                Probar
                </Button>
              </div>
            </Link>
            <Link to='/keras' className='pricing__container-card'>
              <div className='pricing__container-cardInfo'>
                <div className='icon'>
                  <BsCameraVideo />
                </div>
                <h3>Keras CNN-RNN</h3>
                <ul className='pricing__container-features'>
                  <li>Análisis de vídeo</li>
                </ul>
                <Button buttonSize='btn--wide' buttonColor='primary'>
                  Probar
                </Button>
              </div>
            </Link>

            <Link to='/kerasimg' className='pricing__container-card'>
              <div className='pricing__container-cardInfo'>
                <div className='icon'>
                  <BsCamera />
                </div>
                <h3>Keras IMG</h3>
                <ul className='pricing__container-features'>
                  <li>Análisis de imágenes</li>
                </ul>
                <Button buttonSize='btn--wide' buttonColor='primary'>
                  Probar
                </Button>
              </div>
            </Link>
            
          </div>
        </div>
      </div>
    </IconContext.Provider>
  );
}
export default Service;