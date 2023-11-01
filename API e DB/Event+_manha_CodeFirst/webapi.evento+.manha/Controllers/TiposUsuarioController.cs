using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.evento_.manha.Domains;
using webapi.evento_.manha.Interfaces;
using webapi.evento_.manha.Repositories;

namespace webapi.evento_.manha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class TiposUsuarioController : ControllerBase
    {
        private ITiposUsuarioRepository _tiposUsuarioRepository;

        public TiposUsuarioController()
        {
            _tiposUsuarioRepository = new TiposUsuarioRepository();
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
        public IActionResult Get(int id) 
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
            //_tiposUsuarioRepository.BuscarPorId(id);
            return Ok(_tiposUsuarioRepository.BuscarPorId(id));
        }



        [HttpPut("{id}")]
        public IActionResult Update(Guid id, TiposUsuario tiposUsuario)
        {
            try
            {
                _tiposUsuarioRepository.Atualizar(id, tiposUsuario);
                return NoContent();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }

        }
    }
}
