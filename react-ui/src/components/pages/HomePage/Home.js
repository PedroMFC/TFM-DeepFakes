import React from 'react';
import HeroSection from '../../HeroSection';
import { homeObjOne, homeObjTwo, homeObjThree, homeObjFour } from './Data';
import Service from '../../Service';

function Home() {
  return (
    <>
      <HeroSection {...homeObjOne} />
      <Service />
      <HeroSection {...homeObjTwo} />
      <HeroSection {...homeObjThree} />
      <HeroSection {...homeObjFour} />
      
    </>
  );
}

export default Home;