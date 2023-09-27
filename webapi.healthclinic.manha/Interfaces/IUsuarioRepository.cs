using webapi.healthclinic.manha.Domains;

namespace webapi.healthclinic.manha.Interfaces
{
    public interface IUsuarioRepository
    {
        void Cadastrar(Usuario usuario);

        void Deletar(Guid id);
        List<Usuario> Listar();
        Usuario BuscarPorId(Guid id);
        
    }
}
