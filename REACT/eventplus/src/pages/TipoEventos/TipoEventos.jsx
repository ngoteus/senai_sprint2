import React from "react";
import "./TipoEventos.css";
import Title from '../../components/Titulo/Title'
import MainContent from '../../components/Main/MainContent'
import Container from '../../components/Container/Container'


const TiposEvento = () => {
    return(
    <>
        <MainContent>
            <section className="cadastro-evento-section">
                <Container>
                    <div className="cadastro-evento-box">
                        <Title titleText={"Cadastro Tipo de Eventos"} />
                        <ImageIlustrator />   
                        <form className="ftipo-evento">
                            <p>Formulario sera criado aqui+</p>
                        </form>
                    </div>
                </Container>
            </section>
        </MainContent>
    </>
    );
};
export default TiposEvento;