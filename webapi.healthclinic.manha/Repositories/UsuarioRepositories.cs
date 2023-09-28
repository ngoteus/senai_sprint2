using Microsoft.EntityFrameworkCore;
using webapi.healthclinic.manha.Context;
using webapi.healthclinic.manha.Domains;
using webapi.healthclinic.manha.Interfaces;
using webapi.healthclinic.manha.Utils;

namespace webapi.healthclinic.manha.Repositories
{
    public class UsuarioRepositories : IUsuarioRepository
    {
        private readonly HealthClinicContext _healthClinicContext;

        public UsuarioRepositories()
        {
            _healthClinicContext= new HealthClinicContext();
        }

        public Usuario BuscarPorEmailESenha(string email, string senha)
        {
            try
            {
                Usuario usuarioBuscado = _healthClinicContext.Usuario
                    .Select(u => new Usuario 
                    {
                        IdUsuario = u.IdUsuario,
                        Nome = u.Nome,
                        Email= u.Email,
                        Senha= u.Senha,
                        TiposUsuario = new TiposUsuario
                        {
                            IdTipoUsuario = u.IdTipoUsuario,
                            Titulo = u.TiposUsuario!.Titulo
                        }
                    }).FirstOrDefault(u => u.Email == email)!;

                if (usuarioBuscado != null)
                {
                    bool confere = Criptografia.CompararHash(senha, usuarioBuscado.Senha);

                    if (confere) 
                    {
                        return usuarioBuscado;
                    }
                }
                return null!;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Usuario BuscarPorId(Guid id)
        {
            return _healthClinicContext.Usuario.FirstOrDefault(e => e.IdTipoUsuario == id);
        }

        public void Cadastrar(Usuario usuario)
        {
            usuario.Senha = Criptografia.GerarHash(usuario.Senha!);
            _healthClinicContext.Usuario.Add(usuario);
            _healthClinicContext.SaveChanges();

        }

        public void Deletar(Guid id)
        {
            Usuario usuario = _healthClinicContext.Usuario.Find(id)!;

            _healthClinicContext.SaveChanges();
        }

        
    }
}
