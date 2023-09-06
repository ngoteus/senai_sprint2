using senai.inlock.webApi_.Domains;

namespace senai.inlock.webApi_.Interfaces
{
    public class IUsuarioRepository
    {
        UsuarioDomain Login(string Email, string Senha);

    }
}
