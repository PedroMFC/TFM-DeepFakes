import React, { useState } from 'react';
import '../../Form.css';
import FormInitial from '../../FormInitial';
import FormLoading from '../../FormLoading';
import FormSend from './FormSend';
import FormReal from '../../FormReal';
import FormFake from '../../FormFake';

const Form = () => {
  const [isSubmitted, setIsSubmitted] = useState(false);
  const [finalResult, setFinalResult] = useState("");

  function submitForm() {
    setIsSubmitted(true);
  }

  return (
    <>
      <div className='form-container'>
        <div className='form-content-left'>
        {!isSubmitted ? (
          <FormInitial/>
        ) : [(finalResult === "" ?
              <FormLoading /> : [(finalResult == "real" ?
              <FormReal /> :
              <FormFake />
              )]
        ) ]}
        </div>
          <FormSend submitForm={submitForm} setFinalResult={setFinalResult}/>
      </div>
    </>
  );
};

export default Form;
