import React from 'react';
import './Footer.css';
import { Link } from 'react-router-dom';
import {
  FaLinkedin,
  FaGithub
} from 'react-icons/fa';
import { MdFingerprint } from 'react-icons/md';

function Footer() {
  return (
    <div className='footer-container'>
      <section className='social-media'>
        <div className='social-media-wrap'>
          <div className='footer-logo'>
            <Link to='/' className='social-logo'>
              <MdFingerprint className='navbar-icon' />
              Análisis de DeepFakes
            </Link>
          </div>
          <small className='website-rights'>Análisis de DeepFakes © 2021</small>
          <div className='social-icons' >
           
            <Link 
              className='social-icon-link'
              to={
                '//github.com/PedroMFC/TFM-DeepFakes'
              }
              target='_blank'
              aria-label='Github'
            >
              <FaGithub />
            </Link>
            <Link
              className='social-icon-link'
              to={
                '//www.linkedin.com/in/pedro-flores-crespo/'
              }
              target='_blank'
              aria-label='LinkedIn'
            >
              <FaLinkedin />
            </Link>
          </div>
        </div>
      </section>
    </div>
  );
}

export default Footer;