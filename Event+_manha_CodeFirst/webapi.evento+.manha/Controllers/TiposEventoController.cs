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
    public class TiposEventoController : ControllerBase
    {
        private readonly ITiposUsuarioRepository _tiposEventoRepository;

        public TiposEventoController()
        {
            _tiposEventoRepository = new TiposEventoRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_tiposEventoRepository.Listar());
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public IActionResult Post(TiposEvento tiposEvento)
        {
            _tiposEventoRepository.Cadastrar(tiposEvento);
            return Ok(201);
        }

        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _tiposEventoRepository.Deletar(id);
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        public IActionResult Update(Guid id, TiposEvento tiposEvento)
        {
            try
            {
                _tiposEventoRepository.Atualizar(id, tiposEvento);
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
