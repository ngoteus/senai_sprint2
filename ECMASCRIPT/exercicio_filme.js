// const filmes = ["Gente Grande","Panico"]

const filmes = [
    {
        genero: "Ação",
        dataLancamento: "28/09/2001",
        titulo: "Fast Furious",
        descricao: "Brian O Conner é um policial que se infiltra no submundo de rachas para capiturar criminosos",
        diretor: "Rob Cohen"
    },
    {
        genero: "Ação",
        dataLancamento: "12/06/2001",
        titulo: "+Fast +Furious",
        descricao: "ex-policial que volta a se envolver com rachas",
        diretor: "John Singleton"
    },
    {
        genero: "Ação",
        dataLancamento: "11/08/2001",
        titulo: "Velozes e furiosos Desafio em Tóquio",
        descricao: "Sean decide rivalizar com o campeão local de rachas",
        diretor: "Justin Lin"
    }
];
filmes.forEach(({titulo, genero}, i ) => {
    //const { titulo, genero} = f;

    console.log(`
        filme ${i+1}: ${titulo.toUpperCase()}
        genero: ${genero.toString()}
    `)
});