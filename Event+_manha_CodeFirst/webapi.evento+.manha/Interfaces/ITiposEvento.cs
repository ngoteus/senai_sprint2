using webapi.evento_.manha.Domains;

namespace webapi.evento_.manha.Interfaces
{
    public interface ITiposEvento
    {
        void Cadastrar(TiposEvento tiposEvento);
        List<TiposEvento> Listar();
        TiposEvento BuscarPorId(Guid id);
        void Deletar(Guid id);
        void Atualizar(Guid id, TiposEvento tiposEvento);
    }
}
