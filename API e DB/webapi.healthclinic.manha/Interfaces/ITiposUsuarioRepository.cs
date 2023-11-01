using webapi.healthclinic.manha.Domains;

namespace webapi.healthclinic.manha.Interfaces
{
    public interface ITiposUsuarioRepository
    {
        void Cadastrar(TiposUsuario tiposUsuario);

        void Deletar(Guid id);
        List<TiposUsuario> Listar();
        TiposUsuario BuscarPorId(Guid id);
    }
}
