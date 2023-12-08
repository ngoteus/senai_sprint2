import React, { useContext, useEffect, useState } from "react";

import MainContent from "../../components/Main/MainContent";
import Title from "../../components/Titulo/Title";
import Table from "./TableEvA/TableEvA";
import Container from "../../components/Container/Container";
import { Select } from "../../components/FormComponents/FormComponents";
import Spinner from "../../components/Spinner/Spinner";
import Modal from "../../components/Modal/Modal";
import api, {
  commentaryEventResource,
  eventsResource,
  eventsTypeResource,
  myEventsResource,
  presencesEventResource
} from "../../Services/Services";

import "./EventosAlunoPage.css";
import { UserContext } from "../../context/AuthContext";
import userEvent from "@testing-library/user-event";

const EventosAlunoPage = () => {
  // state do menu mobile
  const [exibeNavbar, setExibeNavbar] = useState(false);
  const [tipoEventos, setTipoEventos] = useState("1");
  const [eventos, setEventos] = useState([]);

  // select mocado
  const [quaisEventos, setQuaisEventos] = useState([
    { value: "1", text: "Todos os eventos" },
    { value: "2", text: "Meus eventos" },
  ]);

  const [tipoEvento, setTipoEvento] = useState("1"); //código do tipo do Evento escolhido
  const [showSpinner, setShowSpinner] = useState(false);
  const [showModal, setShowModal] = useState(false);

  // recupera os dados globais do usuário
  const { userData, setUserData } = useContext(UserContext);
  const [ comentario, setComentario ] = useState("");

  async function loadEventsType() {
    // setShowSpinner(true);

    if (tipoEvento === "1") {
      try {
<<<<<<< HEAD
        const retorno = await api.get(eventsResource);
        const meusEventos = await api.get(
          `${myEventsResource}/${userData.userId}`
        );

        const eventosMarcados = verificaPresenca(
          retorno.data,
          meusEventos.data
        );
        console.log(meusEventos);
        console.log("Todos");
        console.log(retorno.data);
        setEventos(eventosMarcados);
=======
        const todosEventos = await api.get(eventsResource);
      const meusEventos = await api.get(
        `${myEventsResource}/${userData.userId}`
      )
      const eventosMarcados = verificaPresenca(todosEventos.data,meusEventos.data);
      setEventos(eventosMarcados)
      console.clear();
      console.log("TODOS OS EVENTOS");
      console.log(todosEventos.data);
      console.log("MEUS EVENTOS")
      console.log(meusEventos);
      console.log("EVENTOS MARCADOS")
      console.log(eventosMarcados)
>>>>>>> 797c0665bcc6d35fdac78a7791bcd729da30a63f
      } catch (error) {
        console.log("Erro na API");
        console.log(error);
      }
    } else if (tipoEvento === "2") {
      try {
<<<<<<< HEAD
        console.log("Meus");
        console.log(`${myEventsResource}/${userData.userId}`);
=======
>>>>>>> 797c0665bcc6d35fdac78a7791bcd729da30a63f
        const retornoEventos = await api.get(
          `${myEventsResourse}/${userData.userId}`
        );


  // async function loadEventsType() {
  //   setShowSpinner(true);
  //   if (tipoEvento === "1") {
  //     try {
  //       const retorno = await api.get(eventsResource);
  //       console.log('Todos');
  //       console.log(retorno.data);
  //       setEventos(retorno.data);
  //     } catch (error) {
  //       console.log("Erro na api1");
  //       console.log(error);
  //     }
  //   } else if (tipoEvento === "2"){
  //     try {
  //       console.log('Meus');
  //       console.log(`${myEventsResource}/${userData.userId}`);
  //       const retornoEventos = await api.get(
  //         `${myEventsResource}/${userData.userId}`
  //       );

        const arrEventos = [];
        retornoEventos.data.forEach((e) => {
          arrEventos.push({...e.eventos,situacao:e.situacao});
        });

        console.log(arrEventos);

        setEventos(arrEventos);
      } catch (error) {
        console.log("Erro na api2");
        console.log(error);
      }
    } else {
      setEventos();
    }
    setShowSpinner(false);
  }

  // async function loadEvents() {
  //   setShowSpinner(true);
  //   if (tipoEvento === "1") {
  //     try {
  //       const retornoEventos = await api.get(eventsResource);
  //       setEventos(retornoEventos.data);
  //     } catch (error) {
  //       alert("Erro na api!");
  //     }
  //     setShowSpinner(false);
  //   } else {
  //     const retornoEventos = await api.get(
  //       `${myEventsResource} /${userData.userId}`
  //     );
  //     setEventos(retornoEventos.data);
  //   }
  //   setShowSpinner(false);
  // }

  useEffect(() => {
    async function loadEventsType() {
      setShowSpinner(true);
      // setEventos([]); //zera o array de eventos
      if (tipoEvento === "1") {
        //todos os eventos (Evento)
        try {
          const todosEventos = await api.get(eventsResource);
          const meusEventos = await api.get(`${myEventsResource}/${userData.userId}`)

          const eventosMarcados = verificaPresenca(todosEventos.data,meusEventos.data)

          console.clear();
          console.log("TODOS OS EVENTOS")
          console.log(todosEventos.data)
          console.log("MEUS EVENTOS")
          console.log(meusEventos.data)
          console.log("EVENTOS  MARCADOS")
          console.log(eventosMarcados);


          setEventos(eventosMarcados)

        } catch (error) {
          //colocar o notification
          console.log("Erro na API");
          console.log(error);
        }
      } else if (tipoEvento === "2") {
        /**
         * Lista os meus eventos (PresencasEventos) 
         * retorna um formato diferente de array
         */
        try {
          const retornoEventos = await api.get(
            `${myEventsResource}/${userData.userId}`
          );
          console.clear()
          console.log("MINHAS PRESENÇAS");
          console.log(retornoEventos.data);

            const arrEventos = [];//array vazio
            
            retornoEventos.data.forEach( e => {
              arrEventos.push(e.evento); 
            });

            // console.log(arrEventos);
          setEventos(arrEventos);
        } catch (error) {
          //colocar o notification
          console.log("Erro na API");
          console.log(error);
        }
      } else {
        setEventos([]);
      }
      setShowSpinner(false);
    }

    // loadEvents();
    loadEventsType();
  }, [tipoEvento]);

  const verificaPresenca = (arrAllEvents, eventsUser) => {
    for (let x = 0; x < arrAllEvents.length; x++) {
      arrAllEvents[x].situacao = false;
      for (let i = 0; i < eventsResource.length; i++) {
        if (arrAllEvents[x].idEvento === eventsUser[i].evento.idEvento) {
          arrAllEvents[x].situacao = true;
<<<<<<< HEAD
          arrAllEvents[x].idPresencaEvento = eventsUser[i].idPresencaEvento
=======
          arrAllEvents[x].idPresencaEvento = eventsUser[i].idPresencaEvento;
>>>>>>> 797c0665bcc6d35fdac78a7791bcd729da30a63f
          break;
        }
      }
    }
    return arrAllEvents;
  };
  // toggle meus eventos ou todos os eventos
  function myEvents(tpEvent) {
    console.log(tpEvent);
    setTipoEvento(tpEvent);
  }

  const loadMyComentary = async (idUsuario, idEvento) => {
    const promise = await api.get(
      `${commentaryEventResource}/BuscarPorIdUsuario/${idUsuario}/${idEvento}`
    );

    console.log(`${commentaryEventResource}/BuscarPorIdUsuario/${idUsuario}/${idEvento}`);

    // console.clear();
    console.log(promise.data.descricao);

    return promise.data.descricao;
  };

  const postMyComentary = () => {
    alert("Cadastrar o comentário");
  };
  const showHideModal = (idEvent) => {
    setShowModal(showModal ? false : true);
    setUserData({ ...userData, idEvento: idEvent });
  };

  const commentaryRemove = () => {
    alert("Remover o comentário");
  };

<<<<<<< HEAD
  async function handleConnect(
    idEvent,
    whatTheFunction,
    idPresencaEvento = null
  ) {
    // conecta o usuário e atualiza a tela
    if (whatTheFunction === "connect") {
      try {
        const promise = await api.post("/Presencas", {
          situacao: true,
          idUsuario: userData.userId,
          idEvento: idEvent,
        });

        if (promise.status === 201) {
          loadEventsType();
          alert("Presença confirmada, parabéns");
        }
      } catch (error) {
        console.log("Erro ao conectar");
        console.log(error);
      }
      return;
    }
    // unconnect - desconecta o usuário e atualiza a listagem
    const promiseDelete = await api.delete("/Presencas/" + idPresencaEvento);
    if (promiseDelete.status === 204) {
      loadEventsType();
      alert("Desconectado do evento");
    }
  }

=======
  async function handleConnect(eventId,whatTheFunction,presencaId = null) {
    if (whatTheFunction === "connect"){

      // {
  
      //   "situacao": true,
      //   "idUsuario": "7032a779-bcbb-4c9c-a651-1fcf90eae853",
      //   "idEvento": "3fa85f64-5717-4562-b3fc-2c963f66afa6"
      // }
  
      try {
        const promise = await api.post(presencesEventResource,{
          situacao:true,
          idUsuario : userData.userId,
          idEvento:eventId
        })
        if (promise.status === 201) {
          alert("Presença confirmada, parabéns")
        }
  
      } catch (error) {
        
      }
  
      try {
        const unconnected = await api.delete(`${presencesEventResource}/${presencaId}`);
        if (unconnected.status === 204){
          const todosEventos = await api.get(eventsResourse);
          setEventos(todosEventos.data)
        }
  
      } catch (error) {
        
      }
  
      alert("CONECTAR AO EVENTO" + eventId);
      return
    }
    alert("DESCONECTAR EVENTO " + eventId)
    }
>>>>>>> 797c0665bcc6d35fdac78a7791bcd729da30a63f
  return (
    <>
      <MainContent>
        <Container>
          <Title titleText={"Eventos"} className="custom-title" />

          <Select
            id="id-tipo-evento"
            name="tipo-evento"
            required={true}
            options={quaisEventos} // aqui o array dos tipos
            manipulationFunction={(e) => myEvents(e.target.value)} // aqui só a variável state
            defaultValue={tipoEvento}
            addclass="select-tp-evento"
          />
          <Table
            dados={eventos}
            fnConnect={handleConnect}
            fnShowModal={showHideModal}
          />
        </Container>
      </MainContent>

      {/* SPINNER -Feito com position */}
      {showSpinner ? <Spinner /> : null}

      {showModal ? (
        <Modal
          userId={userData.userId}
          showHideModal={showHideModal}
          fnGet={loadMyComentary}
          fnPost={postMyComentary}
          fnDelete={commentaryRemove}
          conentaryText={comentario}
        />
      ) : null}
    </>
  );
};

export default EventosAlunoPage;
