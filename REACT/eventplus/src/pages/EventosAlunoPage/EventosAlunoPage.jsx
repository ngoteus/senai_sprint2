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
} from "../../Services/Services";

import "./EventosAlunoPage.css";
import { UserContext } from "../../context/AuthContext";

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
    setShowSpinner(true);
    if (tipoEvento === "1") {
      try {
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
      } catch (error) {
        console.log("Erro na api1");
        console.log(error);
      }
    } else if (tipoEvento === "2") {
      try {
        console.log("Meus");
        console.log(`${myEventsResource}/${userData.userId}`);
        const retornoEventos = await api.get(
          `${myEventsResource}/${userData.userId}`
        );

        const arrEventos = [];
        retornoEventos.data.forEach((e) => {
          arrEventos.push(e.evento);
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
    // loadEvents();
    loadEventsType();
  }, [tipoEvento]);

  const verificaPresenca = (arrAllEvents, eventsUser) => {
    for (let x = 0; x < arrAllEvents.length; x++) {
      arrAllEvents[x].situacao = false;
      for (let i = 0; i < eventsResource.length; i++) {
        if (arrAllEvents[x].idEvento === eventsUser[i].evento.idEvento) {
          arrAllEvents[x].situacao = true;
          arrAllEvents[x].idPresencaEvento = eventsUser[i].idPresencaEvento
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
