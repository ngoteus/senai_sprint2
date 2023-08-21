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
        List<GeneroDomain> ListarTodos();
        void AtualizarIdCorpo(GeneroDomain genero);

        void Deletar(int id);
    }
}
