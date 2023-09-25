using webapi.evento_.manha.Domains;

namespace webapi.evento_.manha.Interfaces
{
    public interface IInstituicaoRepository
    {
        void Cadastrar(Instituicao instituicao);
        void Deletar(Guid id);
        List<Instituicao> Listar();
        Instituicao BuscarPorId(Guid id);
        void Atualizar(Guid id, Instituicao instituicao);
    }
}
