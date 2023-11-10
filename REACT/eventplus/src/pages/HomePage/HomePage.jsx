import React, { useEffect, useState } from "react";
import "./HomePage.css"
import ContactSection from "../../components/ContatcSection/ContactSection";
import VisionSection from "../../components/VisionSection/VisionSection";
import Banner from "../../components/Banner/Banner";
import MainContent from "../../components/Main/MainContent";
import Title from "../../components/Titulo/Title";
import NextEvent from "../../components/NextEvent/NextEvent";
import Container from "../../components/Container/Container";
import axios from "axios";
import api from '../../Services/Services'
import { nextEventResource } from "../../Services/Services";

const HomePage = () => {

    const [nextEvents, setNextEvents] = useState([]);
    useEffect(() => {
      async function getNextEvents(){
        try {
            const promise = await api.get(nextEventResource);
            const dados =  await promise.data;
            console.log(dados);
            setNextEvents(dados);
        } catch (error) {
            alert("Deu ruim na api!")
        }
      }

      getNextEvents();
    }, [])
    return(
            <MainContent>
                <Banner />
                <section className="proximos-eventos">
                    <Container>
                    <Title titleText={"Proximos Eventos"} />

                    <div className="events-box">

                        {
                            nextEvents.map((e) => {
                            return(
                            <NextEvent 
                            key={e.idEvento}
                        title={e.nomeEvento}
                        description={e.descricao}
                        eventDate={e.dataEvento}
                        idEvent={e.idEvento}/> 
                            )
                    })}

                        
                        
                    </div>
                    </Container>
                </section>
                <VisionSection />
                <ContactSection />
            </MainContent>
    );
};
export default HomePage;