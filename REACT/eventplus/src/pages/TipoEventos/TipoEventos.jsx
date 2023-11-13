import React, { useState } from "react";
import "./TipoEventos.css";
import Title from '../../components/Titulo/Title'
import MainContent from '../../components/Main/MainContent'
import Container from '../../components/Container/Container'
import ImageIllustrator from "../../components/ImageIllustrator/ImageIllustrator";
import tipoEventoImage from '../../assets/images/tipo-evento.svg'

const TiposEvento = () => {
    const [frmEdit, setFrmEdit] = useState(false);

    function handleSubmit() {
        alert('Bora cadastrar')
    }
    function handleUpdate(){
        alert('Bora Atualizar')
    }
    return(
    <>
        <MainContent>
            <section className="cadastro-evento-section">
                <Container>
                    <div className="cadastro-evento__box">
                        <Title titleText={"Cadastro Tipo de Eventos"} />

                        <ImageIllustrator
                        imageRender={tipoEventoImage} />   
                        
                        <form 
                        className="ftipo-evento"
                        onSubmit={frmEdit ? handleUpdate: handleSubmit}>
                            {
                                !frmEdit ? (<p>Tela de cadastro</p>) : (<p>Tela de Edição</p>)
                            }
                            
                        </form>
                    </div>
                </Container>
            </section>
        </MainContent>
    </>
    );
};
export default TiposEvento;