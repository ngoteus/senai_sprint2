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
    public class MedicoController : ControllerBase
    {
        private IMedicoRepository _medicoRepository;

        public MedicoController()
        {
            _medicoRepository = new MedicoRepositories();
        }
        /// <summary>
        /// Cadastra um novo médico.
        /// </summary>
        /// <param name="novoMedico">Objeto contendo informações do médico a ser cadastrado.</param>
        /// <returns>StatusCode 201 se bem-sucedido.</returns>
        [HttpPost]
        public IActionResult Post(Medico medico)
        {
            try
            {
                _medicoRepository.Cadastrar(medico);
                return StatusCode(201, medico);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
        /// <summary>
        /// Lista todos os médicos.
        /// </summary>
        /// <returns>Lista de médicos.</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_medicoRepository.Listar());
            }
            catch (Exception e )
            {

                return BadRequest(e.Message);
            }
        }
        /// <summary>
        /// Busca medico pelo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>retorna o medico buscado por id</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                return Ok(_medicoRepository.BuscarPorId(id));
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
        /// <summary>
        /// Deleta um médico específico baseado em seu ID.
        /// </summary>
        /// <param name="id">ID do médico a ser deletado.</param>
        /// <returns>Status 200 OK se bem-sucedido.</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _medicoRepository.Deletar(id);
                return NoContent();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
    }
}
