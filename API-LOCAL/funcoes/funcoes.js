const urlViaCep = "https://viacep.com.br/ws"
const urlCepProfessor = "http://172.16.35.155:3000/myceps"
const urlContato = "http://172.16.35.155:3000/contatos"

async function cadastrar(e) {
    e.preventDefault();
    
    const nome = document.getElementById("nome").value;
    const email = document.getElementById("email").value;
    const cep = document.getElementById("cep").value;
    const endereco = document.getElementById("endereco").value;
    const numero = document.getElementById("numero").value;
    const cidade = document.getElementById("cidade").value;
    const estado = document.getElementById("estado").value;

    //extra - fazer a validacao (dica - crie uma função : bool )
//     if ( !validaForm(nome, endereco, cep)) {//tem campo vazio
//         alert("preencher todos os campos");
//         return;
//     }

//     alert("tudo ok!")
// }

dados = {
    nome,
    email,
    cep,
    endereco,
    numero,
    cidade,
    estado
}

try{
const promise = await fetch('http://172.16.35.155:3000/myceps', {
    data: JSON.stringify(ojbCadastro),
    method: "post",
    headers: {"Content-type": "application/json"}
});
const dados = await promise.json();
console.log(dados);

} catch (error){
    console.log("Deu ruim")
}

// function validaForm(nome, endereco, cep) {
//     console.log(nome);
//     console.log(endereco);
//     console.log(cep);

//     if (
//         nome.length == 0 ||
//         endereco.length == 0 ||
//         cep.length < 8 ||
//     ) {
//         return false;
//     }
//     return true;
// }

async function buscarEndereco(cep) {
    const resource = `/${cep}/json/`
    console.log(`CEP: ${cep}`)
try {
    // const promise = await fetch(urlViaCep + resource);
    
    const promise = await fetch(`${urlCepProfessor}/${cep}`);

    const endereco = await promise.json();
    console.log(endereco);
    

    document.getElementById("endereco").value = endereco.logradouro;
    document.getElementById("cidade").value = endereco.localidade;
    document.getElementById("estado").value = endereco.uf;

    // document.getElementById("not-found").innerText = "";
 } catch(error) {
    console.log(error);

    // document.getElementById("not-found").innerText = "cep inválido";
 }
}