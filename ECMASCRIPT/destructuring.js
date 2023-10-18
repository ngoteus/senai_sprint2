const camisaLacoste = {
    descricao: "Camisa Lacoste",
    preco: 589.97,
    tamanho: "m",
    cor: "Amarela",
    presente: true
}

const {descricao, preco} = camisaLacoste;
const {presente} = camisaLacoste;

console.log("PRODUTO:");
console.log();

console.log(`
    Descrição: ${descricao}
    Preço: ${preco}
    Presente: ${presente ? "sim" :"Nao" }
`);

