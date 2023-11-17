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
import Notification from "../../components/Notification/Notification";



const TiposEvento = () => {
    const [frmEdit, setFrmEdit] = useState(false);
    const [titulo, setTitulo] = useState();
    const [tipoEventos, setTipoEventos] = useState([]);
    const [notifyUser, setNotifyUser] = useState();

    useEffect(()=> {
        async function loadEventsType() {
            try {
              const retorno = await api.get(eventsTypeResource);
            setTipoEventos(retorno.data);
            console.log(retorno.data);
            } catch (error) {
                console.log("Erro na api")
                console.log(error)
            }
            
        }
        loadEventsType()
    }, [])
    // function theMagic() {
    //     setNotifyUser({
    //         titleNote: "Sucesso",
    //         textNote: `Evento excluido com sucesso`,
    //         imgIcon:"success",
    //         imgAlt:
    //           "Imagem de ilustracao de sucesso. Moca segurando um balao com simbolo de confirmacao",
    //         showMessage:true,
    //     });
    // }

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
    function atualizaEventosTela(idEvento) {
        const xpto = tipoEventos.filter((t) =>{
            return t.idEvento !== idEvento;
        });

        setTipoEventos(xpto);
    }
    function handleUpdate(e){
        e.preventDefault();

        
    }

    function editActionAbort() {
        setFrmEdit(false);
        setTitulo("");
    }
    async function showUpdateForm(idElement){
        setFrmEdit(true);
        try {
            const retorno = await api.get(`${eventsTypeResource}/${idElement}`);
            setTitulo(retorno.data.titulo)
            console.log(retorno.data);
        } catch (error) {
            
        }
    }
   async function handleDelete(idElement) {

        if (! window.confirm("Confirma a exclusao?")) {
        

        try {
            const promise = await api.delete(`${eventsTypeResource}/${idElement}`);

            if (promise.status === 204) {
                setNotifyUser({
                    titleNote: "Sucesso",
                    textNote: `Cadastro apagado com sucesso`,
                    imgIcon:"success",
                    imgAlt:
                      "Imagem de ilustracao de sucesso. Moca segurando um balao com simbolo de confirmacao",
                    showMessage:true,
                });
                
                const buscaEventos = await api.get(eventsTypeResource);
                setTipoEventos(buscaEventos.data);
            }
        } catch (error) {
            alert("Problemas ao apagar o elemento")
        }
    }
    }
    
    return(
    <>
        {<Notification {...notifyUser} setNotifyUser={setNotifyUser} />}
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
                                   
                            </>
                            
                            ) : (
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
                                <div className="buttons-editbox">
                                <Button 
                                textButton="Atualizar"
                                id="atualizar"
                                name="Atualizar"
                                type="submit"
                                additionalClass= "button-component--middle"
                                        />
                                <Button 
                                textButton="Cancelar"
                                id="cancelar"
                                name="Cancelar"
                                type="button"
                                manipulationFunction={editActionAbort}
                                        />
                                </div>
                            </>
                            )
                            }
                           
                            
                        </form>
                    </div>
                </Container>
            </section>

            <section className="lista-eventos-section">
                    <Container>
                        <Title titleText={"Lista Tipo de Eventos"} color="white"/>
                        <TableTp 
                            dados={tipoEventos}
                            fnUpdate={showUpdateForm}
                            fnDelete={handleDelete}
                            

                        />
                    </Container>
            </section>
        </MainContent>
    </>
    );
};
export default TiposEvento;