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
    public class PacienteController : ControllerBase
    {
        private IPacienteRepository _pacienteRepository;

        public PacienteController()
        {
            _pacienteRepository = new PacienteRepositories();
        }
        /// <summary>
        /// Lista todos os pacientes.
        /// </summary>
        /// <returns>Lista de pacientes.</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_pacienteRepository.Listar());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        /// <summary>
        /// Cadastra um novo paciente.
        /// </summary>
        /// <param name="novoPaciente">Objeto contendo informações do paciente a ser cadastrado.</param>
        /// <returns>StatusCode 201 se bem-sucedido.</returns>
        [HttpPost]
        public IActionResult Post(Paciente paciente)
        {
            try
            {
                _pacienteRepository.Cadastrar(paciente);

                return StatusCode(201, paciente);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
               
            }
        }
        /// <summary>
        /// Obtém um paciente específico baseado em seu ID.
        /// </summary>
        /// <param name="id">ID do paciente a ser obtido.</param>
        /// <returns>Detalhes do paciente específico.</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                return Ok(_pacienteRepository.BuscarPorId(id));
            }
            catch (Exception e )
            {
                return BadRequest(e.Message);
            }
        }
        /// <summary>
        /// Deleta um paciente específico baseado em seu ID.
        /// </summary>
        /// <param name="id">ID do paciente a ser deletado.</param>
        /// <returns>Status 200 OK se bem-sucedido.</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _pacienteRepository.Deletar(id);
                return NoContent();
            }
            catch (Exception e )
            {

                return BadRequest(e.Message);
            }
        }
    }
}
