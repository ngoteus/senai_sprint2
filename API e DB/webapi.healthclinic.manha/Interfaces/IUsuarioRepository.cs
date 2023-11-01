using webapi.healthclinic.manha.Domains;

namespace webapi.healthclinic.manha.Interfaces
{
    public interface IUsuarioRepository
    {
        void Cadastrar(Usuario usuario);

        void Deletar(Guid id);
        Usuario BuscarPorId(Guid id);

        Usuario BuscarPorEmailESenha(string Email, string senha);
        
    }
}
