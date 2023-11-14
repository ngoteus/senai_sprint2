import React, { useEffect, useState } from "react";
import "./TipoEventos.css";
import Title from '../../components/Titulo/Title'
import MainContent from '../../components/Main/MainContent'
import Container from '../../components/Container/Container'
import ImageIllustrator from "../../components/ImageIllustrator/ImageIllustrator";
import tipoEventoImage from '../../assets/images/tipo-evento.svg'
import { Input, Button } from "../../components/FormComponents/FormComponents";
import api, { eventsTypeResource } from '../../Services/Services'
import TableTp from "./TableTP/TableTp";


const TiposEvento = () => {
    const [frmEdit, setFrmEdit] = useState(false);
    const [titulo, setTitulo] = useState();
    const [tipoEventos, setTipoEventos] = useState([]);

    useEffect(()=> {
        async function loadEventsType() {
            try {
              const retorno = await api.get(eventsTypeResource);
            setTipoEventos(retorno.data)  
            } catch (error) {
                console.log("Erro na api")
                console.log(error)
            }
            
        }
    }, [])

    async function handleSubmit(e) {
       e.preventDefault();
       if (titulo.trim().length < 3) {
        alert("O titulo deve ter pelo menos 3 caracteres")
       }
       try {
        const retorno = await api.post(eventsTypeResource, {
            titulo:titulo
        });
        setTitulo("");
        alert("cadastrado com sucesso")
       } catch (error) {
        alert("deu ruim no submit")
       }
    }
    function handleUpdate(){
        alert('Bora Atualizar')
    }

    function editActionAbort() {
        alert("Cancelar a tela de edicao de dados")
    }
    function showUpdateForm(){
        alert("vamops mostrar o formulario de edicao")
    }
    function handleDelete(idElement) {
        alert(`Vamos apagar o evento de id: ${idElement}`)
    }
    
    return(
    <>
        <MainContent>
            <section className="cadastro-evento-section">
                        <Title titleText={"Cadastro Tipo de Eventos"} />
                <Container>
                    <div className="cadastro-evento__box">

                        <ImageIllustrator
                        imageRender={tipoEventoImage} />   
                        
                        <form 
                        className="ftipo-evento"
                        onSubmit={frmEdit ? handleUpdate: handleSubmit}
                        >
                             
                               { !frmEdit ? (
                                <>
                                <Input 
                            id="Titulo" 
                            placeholder="Título"
                            name={"titulo"}
                            type={"text"}
                            required={"required"}
                            value={titulo}
                            manipulationFunction={(e) =>{
                                setTitulo(e.target.value);
                            }}
                            />
                                
                                    <Button 
                                    textButton="Cadastrar"
                                    id="cadastrar"
                                    name="cadastrar"
                                    type="submit"
                                    />
                                    <span>
                                    {titulo}
                                    </span>
                            </>
                            
                            ) : (<p>Tela de Edição</p>)
                            }
                           
                            
                        </form>
                    </div>
                </Container>
            </section>

            <section className="lista-eventos-section">
                    <Container>
                        <Title titleText={"Lista Tipo de Eventos"} color="white"/>
                        <TableTp 
                            fnUpdate={showUpdateForm}
                            fnDelete={handleDelete}
                            dados={tipoEventos}

                        />
                    </Container>
            </section>
        </MainContent>
    </>
    );
};
export default TiposEvento;