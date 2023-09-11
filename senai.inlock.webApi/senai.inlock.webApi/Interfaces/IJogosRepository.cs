using senai.inlock.webApi_.Domains;

namespace senai.inlock.webApi_.Interfaces
{
    public interface IJogosRepository
    {
        ///tipoRetorno NomeMetodo(tipoParametro nomeParametro)
        void Cadastrar(JogosDomain novoJogo);

        ///Listar todos os objetos cadastrados <summary>
        /// Listar todos os objetos cadastrados
        /// </summary>
        /// <returns>Lista com objetos</returns>
        List<JogosDomain> ListarTodos();
    }
}
