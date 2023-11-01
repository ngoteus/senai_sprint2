using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.inlock.codeFirst.manha.Domains;
using webapi.inlock.codeFirst.manha.Interfaces;
using webapi.inlock.codeFirst.manha.Repositories;
using webapi.inlock.codeFirst.manha.ViewModels;

namespace webapi.inlock.codeFirst.manha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class LoginController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public LoginController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel usuario)
        {
            try
            {
               LoginViewModel login = _usuarioRepository.Login(usuario.Email, usuario.Senha);
                if (login == null)
                {
                    return NotFound("Email e senha invalidos");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
