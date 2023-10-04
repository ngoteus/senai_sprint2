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
    public class ConsultaController : ControllerBase
    {
        private readonly IConsultaRepository _consultaRepository;

        public ConsultaController()
        {
            _consultaRepository = new ConsultaRepositories();
        }
        /// <summary>
        /// Lista todas as consultas disponíveis na clínica.
        /// </summary>
        /// <returns>Uma lista de consultas ou um erro caso algo dê errado.</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_consultaRepository.Listar());
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
        /// <summary>
        /// Cria uma nova consulta na clínica.
        /// </summary>
        /// <param name="novaConsulta">A consulta a ser criada.</param>
        /// <returns>Retorna o status 201 se bem-sucedido, ou um erro caso contrário.</returns>
        [HttpPost]
        public IActionResult Post(Consulta consulta)
        {
            try
            {
                _consultaRepository.Cadastrar(consulta);
                return StatusCode(201);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
        /// <summary>
        /// Busca uma consulta pelo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retprna a consulta buscada pelo id</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                return Ok(_consultaRepository.BuscarPorId(id));
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
        /// <summary>
        /// Deleta uma consulta específica com base no seu ID.
        /// </summary>
        /// <param name="id">O ID da consulta a ser deletada.</param>
        /// <returns>Retorna o status OK se bem-sucedido, ou um erro caso contrário.</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _consultaRepository.Deletar(id);
                return NoContent();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
    }
}
