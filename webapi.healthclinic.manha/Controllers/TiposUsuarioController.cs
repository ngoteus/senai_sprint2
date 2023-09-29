using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.healthclinic.manha.Domains;
using webapi.healthclinic.manha.Interfaces;
using webapi.healthclinic.manha.Repositories;

namespace webapi.healthclinic.manha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class TiposUsuarioController : ControllerBase
    {
        private ITiposUsuarioRepository _tiposUsuarioRepository;

        public TiposUsuarioController() 
        {
            _tiposUsuarioRepository = new TiposUsuarioRepositories();
        }
        [HttpPost]
        public IActionResult Post(TiposUsuario tiposUsuario) 
        {
            try
            {
                _tiposUsuarioRepository.Cadastrar(tiposUsuario);
                return StatusCode(201);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_tiposUsuarioRepository.Listar());
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
                _tiposUsuarioRepository.Deletar(id);
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id) 
        {
            return Ok(_tiposUsuarioRepository.BuscarPorId(id));
        }
    }
}
