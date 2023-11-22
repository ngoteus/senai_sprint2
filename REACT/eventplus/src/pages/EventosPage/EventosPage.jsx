import React from "react";
import './EventosPage.css';
import MainContent from "../../components/Main/MainContent";
import Container from "../../components/Container/Container";
import Titulo from "../../components/Titulo/Title"
import ImageIllustrator from "../../components/ImageIllustrator/ImageIllustrator";
import eventImage from "../../assets/images/evento.svg"
import {Button, Input, Select} from "../../components/FormComponents/FormComponents"
const EventosPage = () => {

    return(
    <MainContent>

        <section className="cadastro-evento-section">
            <Container>
                <div className="cadastro-evento__box">
                    <Titulo titleText={"Pagina de Eventos"}/>

                    <ImageIllustrator imageRender={eventImage}/>
                    <form action="" className="ftipo-evento">
                        <Input 
                        id="nomeEvento"
                        type= "text"
                        name="nomeEvento"
                        placeholder="Nome"
                        required="required"
                          // value={nomeEvento}
                  // manipulationFunction={(e) => {
                  //   // setTitulo(e.target.value);
                        />
                        <Input 
                          id="descricao"
                          type="text"
                          name="descricao"
                          placeholder="Descrição"
                          required="required"
                        />
                        <Input 
                        id="data"
                        type={'date'}
                        name="data"
                        placeholder="dd/mm/aa"
                        required="required"
                        />
                        

                        <Button 
                            textButton="Cadastrar"
                            id="cadastrar"
                            name="cadastrar"
                            type="submit"
                        />
                       
                    </form>
                </div>
            </Container>
        </section>
    </MainContent>
    );
};

export default EventosPage;