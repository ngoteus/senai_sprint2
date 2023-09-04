using webapi.filmes.manha.Domains;

namespace webapi.filmes.manha.Interfaces
{
    public interface IUsuarioInterface
    {
        UsuarioDomain Login(string Email, string Senha);
    }
}
