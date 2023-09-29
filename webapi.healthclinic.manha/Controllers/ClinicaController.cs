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
    public class ClinicaController : ControllerBase
    {
        private IClinicaRepository _clinicaRepository;

        public ClinicaController() 
        {
            _clinicaRepository = new ClinicaRepositories();
        }
        [HttpPost]
        public IActionResult Post(Clinica clinica) 
        {
            try
            {
                _clinicaRepository.Cadastrar(clinica);

                return StatusCode(201);
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
                _clinicaRepository.Deletar(id);
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
            return Ok(_clinicaRepository.BuscarPorId(id));
        }
    }
}
