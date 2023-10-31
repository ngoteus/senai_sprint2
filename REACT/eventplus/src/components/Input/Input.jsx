import React, { useState } from "react";


const Input = ({onChange, value, type, placeholder, name, id}) => {
    // const [numero1, setNumero1] = useState();
    return(
        <>
        <input type={type}
        placeholder={placeholder}
        name={name}
        id={id}
        value={value}
        onChange={onChange}
        
        />
        
        <span>{value}</span>
        </>
    );
};

export default Input;