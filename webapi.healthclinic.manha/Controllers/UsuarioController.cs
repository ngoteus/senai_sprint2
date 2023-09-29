using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.healthclinic.manha.Domains;
using webapi.healthclinic.manha.Interfaces;
using webapi.healthclinic.manha.Repositories;
using webapi.healthclinic.manha.Utils;

namespace webapi.healthclinic.manha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class UsuarioController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository;
        public UsuarioController()
        {
            _usuarioRepository = new UsuarioRepositories();
        }
        [HttpPost]
        public IActionResult Post(Usuario usuario) 
        {
            try
            {
                usuario.Senha = Criptografia.GerarHash(usuario.Senha!);
                _usuarioRepository.Cadastrar(usuario);

                return StatusCode(201);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.InnerException);
                return BadRequest(e.Message);
               
            }
        }
        [HttpGet("{id}")]

        public IActionResult GetById(Guid id)
        {
            

            try
            {
                return Ok(_usuarioRepository.BuscarPorId(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _usuarioRepository.Deletar(id);
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
