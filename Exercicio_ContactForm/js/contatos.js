const urlViaCep = "https://viacep.com.br/ws";

async function cadastrar(e) {
  e.preventDefault();
  
  const dados = {
      nome: document.getElementById("nome").value,
      sobrenome: document.getElementById("sobrenome").value,
      email: document.getElementById("email").value,
      telefone: {
          pais: document.getElementById("pais").value,
          ddd: document.getElementById("DDD").value,
          numero: document.getElementById("telefone").value
      },
      endereco: {
          cep: document.getElementById("cep").value,
          rua: document.getElementById("rua").value,
          numero: document.getElementById("numero").value,
          complemento: document.getElementById("complemento").value,
          bairro: document.getElementById("bairro").value,
          cidade: document.getElementById("cidade").value,
          estado: document.getElementById("UF").value
      },
      anotacoes: document.getElementById("anotacoes").value
  };

  try {
      const response = await axios.post('http://localhost:3000/contatos', dados);

      alert("Dados cadastrados");

  } catch (error) {
      console.error("Erro ao enviar os dados para a API:", error);
      alert("Erro ao enviar os dados para a API. Veja o console para mais detalhes.");
  }
}

async function buscarEndereco(cep) {
  const resource = `/${cep}/json/`;

  try {
    const promise = await fetch(urlViaCep + resource);
    const endereco = await promise.json();

    document.getElementById("rua").value = endereco.logradouro;
    document.getElementById("complemento").value = endereco.complemento;
    document.getElementById("bairro").value = endereco.bairro;
    document.getElementById("cidade").value = endereco.localidade;
    document.getElementById("UF").value = endereco.uf;
    document.getElementById("ddd").value = endereco.ddd;

  } catch (error) {
    console.log(error);
    alert("O CEP digitado é inválido !");
  }
}

function limparFormulario() {
  document.getElementById("nome").value = "";
  document.getElementById("sobrenome").value = "";
  document.getElementById("email").value = "";
  document.getElementById("pais").value = "";
  document.getElementById("ddd").value = "";
  document.getElementById("telefone").value = "";
  document.getElementById("cep").value = "";
  document.getElementById("rua").value = "";
  document.getElementById("numero").value = "";
  document.getElementById("complemento").value = "";
  document.getElementById("bairro").value = "";
  document.getElementById("cidade").value = "";
  document.getElementById("UF").value = "";
  document.getElementById("anotacoes").value = "";
}