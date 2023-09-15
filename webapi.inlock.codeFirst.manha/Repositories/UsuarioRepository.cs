using Microsoft.AspNetCore.Http.HttpResults;
using webapi.inlock.codeFirst.manha.Context;
using webapi.inlock.codeFirst.manha.Domains;
using webapi.inlock.codeFirst.manha.Interfaces;
using webapi.inlock.codeFirst.manha.Utils;

namespace webapi.inlock.codeFirst.manha.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {   
        /// <summary>
        /// Variavel privada e somente leitura para armazenar os dados do contexto
        /// </summary>
        private readonly InlockContext ctx;

        /// <summary>
        /// Construtor do repositorio
        /// Toda vez que o repositorio for instaciado,
        /// Ele tera acesso aos dados fornecidos pelo contexto
        /// </summary>
        public UsuarioRepository() 
        {
            ctx = new InlockContext();
        }
        public Usuario BuscarUsuario(string email, string senha)
        {
            try
            {
                Usuario usuarioBuscado = ctx.Usuario.FirstOrDefault(u => u.Email == email)!;

                if (usuarioBuscado != null) 
                {
                    bool Confere = Criptografia.CompararHash(senha, usuarioBuscado.Senha!);

                    if (Confere) 
                    {
                        return usuarioBuscado;
                    }
                }
                return null;
            }
            catch (Exception)
            {
                throw;
                
            }
        }

        public void Cadastrar(Usuario usuario)
        {
            try
            {
             usuario.Senha = Criptografia.GerarHash(usuario.Senha);

                ctx.Usuario.Add(usuario);


                ctx.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
           
        }
    }
}
