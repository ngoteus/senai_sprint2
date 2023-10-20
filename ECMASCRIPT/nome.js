const nome = ["Lucas","Guilherme","Arthur","Eduardo"]

const sobrenome = ["Lacerda","César","Fiorentino","Merbach"]

const nomeCompleto = nome.map((nome,indice)=> `${nome} ${sobrenome[indice]}`)

nomeCompleto.forEach((nc)=>{console.log(nc);});