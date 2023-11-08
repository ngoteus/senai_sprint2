import React from "react";
import "./HomePage.css"
import ContactSection from "../../components/ContatcSection/ContactSection";
import VisionSection from "../../components/VisionSection/VisionSection";
import Banner from "../../components/Banner/Banner";
import MainContent from "../../components/Main/MainContent";
import Title from "../../components/Titulo/Title";
import NextEvent from "../../components/NextEvent/NextEvent";
import Container from "../../components/Container/Container";

const HomePage = () => {
    return(
            <MainContent>
                <Banner />
                <section className="proximos-eventos">
                    <Container>
                    <Title titleText={"Proximos Eventos"} />

                    <div className="events-box">
                        <NextEvent 
                        title={"Evento X"}/>
                        <NextEvent />
                        
                    </div>
                    </Container>
                </section>
                <VisionSection />
                <ContactSection />
            </MainContent>
    );
};
export default HomePage;