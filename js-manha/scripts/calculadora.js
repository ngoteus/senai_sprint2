function calcular() {
    event.preventDefault(); //parar o submir do formulario
    //criar uma variavel para cada número
    //criar uma variavel com o resultado da soma 
    //exibir o resultado em uma alert - UTILIZAR INTERPOLAÇÃO

    let n1 = parseInt(document.getElementById("n1").value); //CAMPO 1
    let n2 = parseInt(document.getElementById("n2").value); // CAMPO 2
    let operacao = document.getElementById("operacao").value // VALOR SELECIONADO NO SELECT
    let resultado;

    if (isNaN(n1) || isNaN(n2)) {
        alert("É necessário digitar um número!");
        return;
    }

    if (operacao == "+") {
        resultado = somar(n1, n2);
    } else if (operacao == "-") {
        resultado = subtrair(n1, n2);
    } else if (operacao == "/") {
        resultado = dividir(n1, n2)
    } else if (operacao == "*") {
        resultado = multiplicar(n1, n2)
    } else {
        alert("Informe uma opção válida!")
    }

    //INSERIR O RESULTADO NO HTML(DOM)
    document.getElementById('result').innerText = resultado;
    // alert(`O resultado é:  ${resultado}`)
}
function somar(x, y) {
    return x + y;
}
function subtrair(x, y) {
    return x - y;
}
function dividir(x, y) {
    if (y == 0) {
        return "não existe divisão por zero!";
    }
    return x / y;
}
function multiplicar(x, y) {
    return x * y;
}