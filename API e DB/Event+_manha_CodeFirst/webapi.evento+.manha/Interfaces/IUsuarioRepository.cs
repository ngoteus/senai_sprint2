using webapi.evento_.manha.Domains;

namespace webapi.evento_.manha.Interfaces
{
    public interface IUsuarioRepository
    {
        void Cadastrar(Usuario usuario);

        Usuario BuscarPorId(Guid id);

        Usuario BuscarPorEmailESenha(string email, string senha);
    }
}
