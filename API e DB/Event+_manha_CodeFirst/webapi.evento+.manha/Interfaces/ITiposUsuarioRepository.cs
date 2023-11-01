using webapi.evento_.manha.Domains;

namespace webapi.evento_.manha.Interfaces
{
    public interface ITiposUsuarioRepository
    {
        void Cadastrar(TiposUsuario tipoUsuario);

        void Deletar(Guid id);

        List<TiposUsuario> Listar();

        TiposUsuario BuscarPorId(Guid id);

        void Atualizar(Guid id, TiposUsuario tipoUsuario);
    }
}
