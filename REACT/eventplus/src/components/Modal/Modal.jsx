import React, { useContext, useEffect, useState } from "react";
import trashDelete from "../../assets/images/trash-delete-red.png";

import { Button, Input } from "../FormComponents/FormComponents";
import "./Modal.css";
import { UserContext } from "../../context/AuthContext";

const Modal = ({
  modalTitle = "Feedback",
  // comentaryText = "Não informado. Não informado. Não informado.",
  // userId = null,
  showHideModal = false,
  fnGet = null,
  fnPost = null,
  fnDelete = null,

}) => {

  const {userData} = useContext(UserContext)
  console.clear()
  console.log(userData);

  const [postedCommentaryText, setPostedCommentaryText] = useState('');
  const [comentarioDesc, setComentarioDesc] = useState("")

  async function carregarDados() {
    const description = await fnGet(userData.userId, userData.idEvento)
    console.log(description);
    setPostedCommentaryText(description)
  }

  useEffect(() => {
    carregarDados();
  }, [])

  
  return (
    <div className="modal">
      <article className="modal__box">
        
        <h3 className="modal__title">
          {modalTitle}
          <span className="modal__close" onClick={()=> showHideModal(true)}>x</span>
        </h3>

        <div className="comentary">
          <h4 className="comentary__title">Comentário</h4>
          <img
            src={trashDelete}
            className="comentary__icon-delete"
            alt="Ícone de uma lixeira"
            onClick={fnDelete}
          />

          <p className="comentary__text">{postedCommentaryText}</p>

          <hr className="comentary__separator" />
        </div>

        <Input
          placeholder="Escreva seu comentário..."
          additionalClass="comentary__entry"
          value={comentarioDesc}
          manipulationFunction={(e) => {
            setComentarioDesc(e.target.value)
          }}
        />

        <Button
          buttonText="Comentar"
          additionalClass="comentary__button"
          manipulationFunction={() =>{
            fnPost(comentarioDesc, userData.userId, userData.idEvento)
          }}
        />

      </article>
    </div>
  );
};

export default Modal;
