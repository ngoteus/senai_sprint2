import './App.css';
import CardEvento from './componentes/CardEvento/CardEvento';
import Container from './componentes/Container/Container';
import Title from './componentes/Title/Title';

function App() {
  return (
    <div className="App">
      <h1>Hello World React</h1>
      <Title text=" Eduardo Costa"/>

      <br /><br />
      <Container>
      <CardEvento
        titulo="Sql Server"
        texto= "lorem"
        textoLink="Conectar"
      />
        
      <CardEvento
        titulo="JavaScript"
        texto= "lorem"
        textoLink="Conectar"
      />
        
      <CardEvento
        titulo="C Sharp"
        texto= "lorem"
        textoLink="Conectar"
      />
        </Container>
    </div>
  );
}

export default App;
