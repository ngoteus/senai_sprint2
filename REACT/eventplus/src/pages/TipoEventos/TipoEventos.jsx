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
import Spinner from "../../components/Spinner/Spinner"



const TiposEvento = () => {
    const [frmEdit, setFrmEdit] = useState(false);
    const [titulo, setTitulo] = useState();
    const [tipoEventos, setTipoEventos] = useState([]);
    const [notifyUser, setNotifyUser] = useState();
    const [showSpinner, setShowSpinner] = useState(false)
    const [IdTipoEvento, setIdTipoEvento]= useState([])

    useEffect(()=> {
        async function loadEventsType() {
            setShowSpinner(true)

            try {
              const retorno = await api.get(eventsTypeResource)
              setTipoEventos(retorno.data)
              
            } 
            
            catch (error) {
              console.log("Erro na api")
              console.log(error);
      
            }
            setShowSpinner(false);
            
        }
        loadEventsType();
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
      if (titulo.trim().length <3) { setNotifyUser({
        titleNote:"Aviso",
        textNote:`O título dee ter pelo menos 3 caracteres`,
        imgIcon:"warning",
        imgAlt:
        "Imagem de ilustração de aviso.Moça em frente a um símbolo de exclamação",
        showMessage:true  
      });
        
      }

      setShowSpinner(true)
      try {
        const retorno = await api.get(eventsTypeResource, {
            titulo:titulo,
        });
        setTitulo("");

        setNotifyUser({
            titleNote:"Sucesso",
            textNote:`Tipo de evento Cadastrado`,
            imgIcon:"success",
            imgAlt:
            "Imagem de ilustração de sucesso.Moça segurando um balão com simbolo de confirmação ok",
            showMessage:true   
        });
        const buscaEventos = await api.get(eventsTypeResource)

         setTipoEventos(buscaEventos.data);
      } catch (e) {
        setNotifyUser({
            titleNote:"Erro",
            textNote:`Deu ruim no submit`,
            imgIcon:"Danger",
            imgAlt:
            "Imagem de ilustração de erro.Rapaz segurando um balão com simbolo x",
            showMessage:true   
        
          });
          setShowSpinner(false);
      }

    }
    
    function atualizaEventosTela(idEvento) {
        const xpto = tipoEventos.filter((t) =>{
            return t.idEvento !== idEvento;
        });

        setTipoEventos(xpto);
    }
    async function handleUpdate(e){
        e.preventDefault();

        setShowSpinner(true)
        try {
            const edit=await api.put(eventsTypeResource+'/'+IdTipoEvento, {titulo:titulo})

            if (edit.status===204) {

                setTitulo("");
                setIdTipoEvento(null)
                setNotifyUser({
                  titleNote:"Sucesso",
                  textNote:`Tipo de evento Atualizado`,
                  imgIcon:"success",
                  imgAlt:
                  "Imagem de ilustração de sucesso.Moça segurando um balão com simbolo de confirmação ok",
                  showMessage:true   
              
                });

                const retorno = await api.get(eventsTypeResource) //Retorno do array
    setTipoEventos(retorno.data)

    editActionAbort();
        }
    }
        catch (error) {
            setNotifyUser({
                titleNote:"Erro",
                textNote:`Erro na operação.Por favor verifique sua conexão`,
                imgIcon:"danger",
                imgAlt:
                "Imagem de ilustração de erro.Rapaz segurando um balão com simbolo x",
                showMessage:true   
            
              });
        }
        
        setShowSpinner(false)

        
    }

    function editActionAbort() {
        setFrmEdit(false);
        setTitulo("");
        setIdTipoEvento(null)
    }
    async function showUpdateForm(idElement){
        setIdTipoEvento(idElement)
        setFrmEdit(true);
        try {
            const retorno = await api.get(`${eventsTypeResource}/${idElement}`);
            setTitulo(retorno.data.titulo)
        } catch (error) {
            
        }
    }
   async function handleDelete(idElement) {

        if (! window.confirm("Confirma a exclusao?")) {
        return;
            }
            setShowSpinner(true);
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
            setNotifyUser({
                titleNote:"Erro",
                textNote:`Erro na exclusão do cadastro`,
                imgIcon:"danger",
                imgAlt:
                "Imagem de ilustração de erro.Rapaz segurando um balão com simbolo x",
                showMessage:true  
        });
    
    setShowSpinner(false);
    }
}
    
    return(
    <>
        {<Notification {...notifyUser} setNotifyUser={setNotifyUser} />}

        {showSpinner ? <Spinner/>:null}
        <MainContent>
            <section className="cadastro-evento-section">
                        <Title titleText={"Cadastro Tipo de Eventos"} />
                <Container>
                    <div className="cadastro-evento__box">

                        

                        <ImageIllustrator
                        imageRender={tipoEventoImage} />   
                        
                        <form 
                        action=""
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
                                addClass="button-component--middle"
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