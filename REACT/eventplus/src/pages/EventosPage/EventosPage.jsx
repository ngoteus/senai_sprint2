import React, { useEffect, useState } from "react";
import './EventosPage.css';
import MainContent from "../../components/Main/MainContent";
import Container from "../../components/Container/Container";
import Titulo from "../../components/Titulo/Title"
import ImageIllustrator from "../../components/ImageIllustrator/ImageIllustrator";
import eventImage from "../../assets/images/evento.svg"
import {Button, Input, Select} from "../../components/FormComponents/FormComponents"
import api, { eventsResource, eventsTypeResource } from "../../Services/Services";
import TableEv from "./TableTp/TableEv";
import TiposEvento from "../TipoEventos/TipoEventos";
const EventosPage = () => {

    const IdInstituicao = "b697bd61-3c72-42d9-bd31-ef10399afd1f"
    const [frmEdit, setFrmEdit] = useState(false);
    const [eventos, setEventos] = useState([])
    const [nomeEvento, setNomeEvento] = useState()
    const [dataEvento, setDataEvento] = useState()
    const [descricao, setDescricao] = useState()
    const [idEvento, setIdEvento] = useState(null)
    const [tipoEventos, setTipoEventos] = useState([])
    const [IdTipoEvento, setIdTipoEvento] = useState();

    useEffect(() => {
        async function loadEvents() {
            try {
                const retorno = await api.get(eventsResource)
                setEventos(retorno.data)

            } catch (error) {
                alert("Erro na api!")
            }
        }
        loadEvents();
    })

    useEffect(() => {
        async function loadEventsType() {
            try {
                const retorno = await api.get(eventsTypeResource)
                setTipoEventos(retorno.data)
            } catch (error) {
                alert("erro na api")
            }
        }
        loadEventsType();
    })

    async function handleSubmit(e) {
        e.preventDefault();
        if (nomeEvento.trim().length < 3) {
            alert('Nome do evento deve conter pelo menos 3 caracteres')
            return;
        }

        try {
            const promise = await api.post(eventsResource, 
                {dataEvento: dataEvento,
                 nomeEvento: nomeEvento,
                 descricao: descricao,
                 idTipoEvento: tipoEventos,
                 idInstituicao: IdInstituicao
                })

                if (promise.status == 201) {
                    const buscaEventos = await api.get(eventsResource);
                    setEventos(buscaEventos.data)
                }

        } catch (error) {
            alert('erro')
        }
    }
    async function handleUpdate(e) {
        e.preventDefault();
        if (nomeEvento.trim().length < 3) {
            alert('Nome do evento deve conter pelo menos 3 caracteres')
            return;
        }
        try {
            const promise = await api.put(`${eventsResource}/${idEvento}`, {
                dataEvento: dataEvento,
                nomeEvento: nomeEvento,
                descricao: descricao,
                IdTipoEvento: IdTipoEvento
            })
        } 
        catch (error) {

        }
    }   
 

    async function showUpdateForm(idElement) {
        setFrmEdit(true)
        try {
            const promise = await api.get(`${eventsResource}/${idElement}`, { idElement })
            setDataEvento(promise.data.dataEvento)
            setNomeEvento(promise.data.nomeEvento)
            setDescricao(promise.data.descricao)
            setIdTipoEvento(promise.data.idTipoEvento)

        } catch (error) {
            alert('erro em atualizar')
        }
    }

    async function handleDelete(idElement)
    {
       if (window.confirm('Confirma a exclusao?')) {
        try {
            const promise = await api.delete(`${eventsResource}/${idElement}`,{idElement})
            if (promise.status == 204) {
                const buscaEventos = await api.get(eventsResource);
                setEventos(buscaEventos.data)
            }
        } catch (error) {
            alert("Erro para excluir")
        }
       }
     }
   
    function tituloTipo(tipoEventos) {
        let arrayOptions = []

        tipoEventos.forEach(element => {
            arrayOptions.push({ value: element.IdTipoEvento, text: element.titulo })
        })
        return arrayOptions
    }


    return(
        <>
    <MainContent>

        <section className="cadastro-evento-section">
            <Container>

                <div className="cadastro-evento__box">
                    <Titulo titleText={"Pagina de Eventos"}/>

                    <ImageIllustrator imageRender={eventImage}/>

                    <form 
                    action="" 
                    className="ftipo-evento"
                    
                    >
                        
                        <Input 
                        id="nomeEvento"
                        type= "text"
                        name="nomeEvento"
                        placeholder="Nome"
                        required="required"
                          value={nomeEvento}
                  manipulationFunction={(e) => {
                    setNomeEvento(e.target.value);
                  }}
                        />
                        <Input 
                          id="descricao"
                          type="text"
                          name="descricao"
                          placeholder="Descrição"
                          required="required"
                          value={descricao}
                          manipulationFunction={(e) => {
                              setDescricao(e.target.value)
                          }}
                        />
                        <Input 
                        id="data"
                        type={'date'}
                        name="data"
                        placeholder="dd/mm/aa"
                        required="required"
                        value={dataEvento}
                                    manipulationFunction={(e) => {
                                        setDataEvento(e.target.value)
                                    }}
                        />
                         <Select
                                    id='TiposEvento'
                                    name={'tiposEvento'}
                                    required={'required'}
                                    options={tituloTipo(tipoEventos)}
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
        <section className="lista-eventos-section">
            <Container>
                <Titulo titleText={"Lista de Eventos"} color={"white"}/>

                <TableEv 
                dados={eventos}
                fnUpdate={showUpdateForm}
                fnDelete={handleDelete}
                
                />
            </Container>
        </section>
    </MainContent>
    </>
    );
    
    };

export default EventosPage;