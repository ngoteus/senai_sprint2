import React, {useState} from "react";
import Header from '../../components/Header/Header'
import Input from "../../components/Input/Input";
import Button from "../../components/Button/Button";

const TestePage = () => {
    const [n1, setN1] = useState(0);
    const [n2, setN2] = useState(0);
    const [total, setTotal] = useState(0);

    function handleCalcular(e) {
        e.preventDefault();
        setTotal(parseFloat(n1) +  parseFloat(n2));
    }

    return (
        <div>

            {/* <Header /> */}
            <h1>Pagina de poc´s</h1>
            <h2>Calculator</h2>

            <form onSubmit={handleCalcular}
            
            >
                <Input 
                type="number"
                placeholder="Primeiro numero"
                name="n1"
                id="n1" 
                value={n1}
                onChange={(e) => {setN1(e.target.value)}}
                />
                <br />
                <Input 
                type="number"
                placeholder="segundo numero"
                name="n2"
                id="n2" 
                value={n2}
                onChange={(e) => {setN2(e.target.value)}}
                />

                <br />

                <Button 
                    textButton="Calcular"
                    type="submit"
                />
                <span>
                    Resultado: 
                    <strong >
                        {total}
                    </strong>
                </span>
            </form>
            {/* <p>VALOR DO N1: {n1}</p>
            <p>VALOR DO N1: {n2}</p> */}
        </div>
    )
}

export default TestePage;