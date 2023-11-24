import React from 'react';
import './FormComponents.css'

export const Input = ( {
    type,
    id,
    value,
    required,
    name,
    placeholder,
    manipulationFunction,
    additionalClass = '',
} ) => {
    function teste(valor) {
        console.log("ola")
    }
    return(
        <input 
        type={type} 
        id={id} 
        name={name}
        value={value} 
        required={required ? "required" : ""} 
        className={`input-component ${additionalClass}`}
        placeholder={placeholder}
        onChange={manipulationFunction}
        autoComplete="off"
         />
    );
};


export const Label = ({htmlFor, labelText}) => {
    return <label htmlFor={htmlFor}>{labelText}</label>
}

export const Button = ( props ) => {
    return(
        <button 
            id={props.id}
            name={props.name}
            type={props.type}
            className={`button-component ${props.addclass}`}
            onClick={props.manipulationFunction}
            >
            {props.textButton}
        </button>
    );
}

        export const Select = ({
            required,
            id,
            name,
            options,
            manipulationFunction,
            addclass = "",
            value
        }) => {
    return(
        <select 
        name={name}
         id={id}
         required={required}
         className={`input-component ${addclass}`}
         onChange={manipulationFunction}
         value={value}
         >
            <option value="">Tipo Evento</option>
            {options.map((o) => {
            return(
                <option key={Math.random()} value={o.value}>
                    {o.text}
                </option>
            )}
            )}
        </select>
    )
}