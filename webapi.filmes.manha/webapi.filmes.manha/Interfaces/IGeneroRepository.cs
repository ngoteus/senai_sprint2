using webapi.filmes.manha.Domains;

namespace webapi.filmes.manha.Interfaces
{
    /// <summary>
    /// Interface responsavel pelo repositorio GeneroRepository
    /// Definir os metodos que serao implementados pelo GeneroRepository
    /// </summary>
    public interface IGeneroRepository
    {
        ///tipoRetorno NomeMetodo(tipoParametro nomeParametro)

        void Cadastrar(GeneroDomain novoGenero);
        ///Listar todos os objetos cadastrados <summary>
        /// Listar todos os objetos cadastrados
        /// </summary>
        /// <returns>Lista com objetos</returns>
        List<GeneroDomain> ListarTodos();
        /// <summary>
        /// Atualizar objeto existente passando o seu id pelo corpo da requisicao
        /// </summary>
        /// <param name="genero">objeto atualizado (novas informacoes)</param>
        void AtualizarIdCorpo(GeneroDomain genero);
        /// <summary>
        /// Atualizar objeto existente passando o seu id pela url
        /// </summary>
        /// <param name="id">Id do objeto que sera atualizado</param>
        /// <param name="genero">Ob jeto atualizado (novas informacoes)</param>
        void AtualizarIdUrL(int id, GeneroDomain genero);
        /// <summary>
        /// Deletar um objeto
        /// </summary>
        /// <param name="id">Id do objeto que sera deletado</param>
        void Deletar(int id);
        /// <summary>
        /// Busca por um objeto atraves do seu id
        /// </summary>
        /// <param name="id">Id do objeto a ser buscado</param>
        /// <returns>Objeto buscado</returns>

        GeneroDomain BuscarPorId(int id);
    }
}
