import React from 'react';

import './Nav.css'

import logMobile from '../../assets/images/logo-white.svg'
import logDesktop from '../../assets/images/logo-pink.svg'

import { Link } from 'react-router-dom';

const Nav = ({exibeNavBar, setExibeNavBar}) => {

    console.log(`EXIBE O MENU? ${exibeNavBar}`)

    
    return(
        <nav className={`navbar ${exibeNavBar ? "exibeNavBar" : "" }`}>

            <span onClick={() => {setExibeNavBar(false)}}  
            className='navbar__close' 
            >
                x
                </span>

            
            <Link  to="/" className='eventlogo'>

            <img
             className='eventlogo__logo-image'
            src={window.innerWidth >= 992 ? logDesktop : logMobile}
             alt="Event Plus Logo" />
            </Link>

            <div className='navbar__items-box'>
                <Link to="/">Home</Link>
                <Link to="/tipo-evento">Tipos de Eventos</Link>
                <Link to="/evento">Eventos</Link>
                <Link to="/login">Login</Link>
                <Link to="/teste">testes</Link>
            </div>
            
            <button onClick={() => {setExibeNavBar(true)}}>mostrar menu</button>
        </nav>
    );
};
export default Nav;