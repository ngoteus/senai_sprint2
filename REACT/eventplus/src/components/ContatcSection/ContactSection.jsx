import React from 'react';
import './ContactSection.css'
import Title from '../Titulo/Title'
import contatoMap from '../../assets/images/contato-map.png'

const ContactSection = () => {
    return (
        <section className='contato'>
            <Title titleText={"Contato"}/>

            <div className="contato__endereco-box">
                <img src={contatoMap} alt="" className='contato__img-map'
                
                />
                <p>
                    Rua Niteroi, 188 - Centro <br />
                    São Caetano do Sul - SP
                    <a 
                    href="tel:+551142252000"
                    className='contato__telefone'
                    >
                        (11) 4225-2000
                    </a>
                </p>
            </div>        
        </section>
    );
};

export default ContactSection;