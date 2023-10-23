const urlViaCep = "https://viacep.com.br/ws"
const urlCepProfessor = "http://172.16.35.155:3000/myceps"

function cadastrar(e) {
    e.preventDefault();
    alert("Cadastrar...");
}

async function buscarEndereco(cep) {
    const resource = `/${cep}/json/`
try {
    // const promise = await fetch(urlViaCep + resource);
    
    const promise = await fetch(`${urlCepProfessor}/${cep}`);

    const endereco = await promise.json();
    console.log(endereco);
    return;

    getElementById("endereco").value = endereco.logradouro;
    getElementById("cidade").value = cidade.localidade;
    getElementById("estado").value = cidade.uf;

    document.getElementById("not-found").innerText = "";
 } catch(error) {
    console.log(error);

    document.getElementById("not-found").innerText = "cep inválido";
 }
}