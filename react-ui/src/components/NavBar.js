import React, {useState, useEffect} from 'react'
import { Link } from 'react-router-dom'
import { BiFace } from 'react-icons/bi'
import { FaBars, FaTimes } from 'react-icons/fa'
import './NavBar.css'
import { IconContext } from 'react-icons/lib'

function NavBar() {
    const [click, setClick] = useState(false)
    const [button, setButton] = useState(true)

    const handleClick = () => setClick(!click)
    const closeMobileMenu = () => setClick(false)

    const showButton = () => {
        if(window.innerWidth <= 960){
            setButton(false)
        } else{
            setButton(true)
        }
    }

    useEffect(() => {
        showButton()
    }, [])

    window.addEventListener('resize', showButton)

    return (
        <>
          <IconContext.Provider value={{ color: '#fff' }}>
            <nav className='navbar'>
              <div className='navbar-container container'>
                <Link to='/' className='navbar-logo' onClick={closeMobileMenu}>
                  <BiFace className='navbar-icon' />
                  Análisis de DeepFakes
                </Link>
                <div className='menu-icon' onClick={handleClick}>
                  {click ? <FaTimes /> : <FaBars />}
                </div>
                <ul className={click ? 'nav-menu active' : 'nav-menu'}>
                  <li className='nav-item'>
                    <Link to='/faceforensics' className='nav-links' onClick={closeMobileMenu}>
                      Faceforensics
                    </Link>
                  </li>
                  <li className='nav-item'>
                    <Link
                      to='/reverse'
                      className='nav-links'
                      onClick={closeMobileMenu}
                    >
                      ReverseEngineering
                    </Link>
                  </li>
                  <li className='nav-item'>
                    <Link
                      to='/keras'
                      className='nav-links'
                      onClick={closeMobileMenu}
                    >
                      Keras CNN-RNN
                    </Link>
                  </li>
                </ul>
              </div>
            </nav>
          </IconContext.Provider>
        </>
      );
}

export default NavBar
