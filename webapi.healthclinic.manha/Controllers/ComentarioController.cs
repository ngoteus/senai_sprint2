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
    public class ComentarioController : ControllerBase
    {
        private IComentarioRepository _comentarioRepository;

        public ComentarioController()
        {
            _comentarioRepository = new ComentariosRepositories();
        }
        [HttpPost]
        public IActionResult Post(Comentario comentario)
        {
            try
            {
                _comentarioRepository.Cadastrar(comentario);
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
                return Ok(_comentarioRepository.Listar());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet("{id}")]

        public IActionResult GetById(Guid id) 
        {
            return Ok(_comentarioRepository.BuscarPorId(id));
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id) 
        {
            try
            {
                _comentarioRepository.Deletar(id);
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            
        }
    }
}
