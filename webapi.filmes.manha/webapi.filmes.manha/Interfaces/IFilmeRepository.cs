using webapi.filmes.manha.Domains;

namespace webapi.filmes.manha.Interfaces
{
    public interface IFilmeRepository
    {
        void CadastrarFilme (FilmeDomain filme);

        List<FilmeDomain> ListarTodos();

        void AtualizarIdCorpo(FilmeDomain filme);

        void AtualizarIdUrl(int id, FilmeDomain filme);

        void Deletar(int id);

        FilmeDomain BuscaPorId(int id);

    }
}
