// const numeros = [1, 2, 5, 10, 300];

// const arrDobro = numeros.map((n) => {
//     return n * 2;
// })

// console.log(numeros);
// console.log(arrDobro)


const nomes = ["Mateus", "Wanderson", "Eduardo", "Wender"  , "Carlos"];
const sobrenomes = ["Moura", "Bonfim" , "Mendes", "Merbachi", "Macedo"]
const nomeCompleto = nomes.map((nome,indice) =>{
    return `${nome} ${sobrenomes[indice]}`;
});

nomeCompleto.forEach((nc) => {
    console.log(nc)
})
    
