//rsc

import React, {useState} from 'react';

const Contador = () => {
    const [contador, setContador] = useState(0);

    function handleIncrementar() {
        setContador( contador  + 1);
    }
    function handleDecrementar() {
        setContador( contador === 0 ? 0 : contador - 1)
            //funcionam da mesma forma
        // if(contador === 0) {
        //     setContador(0)
        // } else {
        //     setContador(contador -1);
        // }
    }

    return (
        <div>
            <h1>Contador</h1>

            <p>{contador}</p>
            <button onClick={() =>
            {handleIncrementar()}}>Incrementar</button>

            <button onClick={() => 
            {handleDecrementar()}}>Descrementar</button>
        </div>
    );
};

export default Contador;