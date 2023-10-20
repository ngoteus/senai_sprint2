const urlViaCep = "https://viacep.com.br/ws"

function cadastrar(e) {
    e.preventDefault();
    alert("Cadastrar...");
}

async function buscarEndereco(cep) {
    const resource = `/${cep}/json/`
try {
    const promise = await fetch(urlViaCep + resource);

    const endereco = await promise.json();
    console.log(endereco);

    getElementById("endereco").value = endereco.logradouro;
    getElementById("cidade").value = cidade.localidade;
    getElementById("estado").value = cidade.uf;

    document.getElementById("not-found").innerText = "";
 } catch(error) {
    console.log(error);

    document.getElementById("not-found").innerText = "cep inválido";
 }
}