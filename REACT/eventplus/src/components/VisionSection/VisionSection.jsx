import React from 'react';
import Title from '../Titulo/Title'
import './VisionSection.css'

const VisionSection = () => {
    return (
        <section className='vision'>
            <div className='vision__box'>
                <Title 
                    titleText={"visao"}
                    color='white'
                    potatoClass='vision__title'
                />
                <p className='vision__text'>Lorem ipsum dolor sit amet.</p>
            </div>
        </section>
    );
};

export default VisionSection;