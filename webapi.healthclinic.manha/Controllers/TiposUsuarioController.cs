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
        /// <summary>
        /// Cadastra um novo tipo de usuário.
        /// </summary>
        /// <param name="novoTipoUsuario">Objeto contendo informações do tipo de usuário a ser cadastrado.</param>
        /// <returns>StatusCode 201 se bem-sucedido.</returns>
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
        /// <summary>
        /// Lista todos os tipos de usuários cadastrados.
        /// </summary>
        /// <returns>Uma lista de tipos de usuários.</returns>
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
        /// <summary>
        /// Deleta o tipo de usuario pelo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna o tipo de usuario deletado</returns>
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
        /// <summary>
        /// Obtém um tipo de usuário específico baseado em seu ID.
        /// </summary>
        /// <param name="id">ID do tipo de usuário a ser obtido.</param>
        /// <returns>Detalhes do tipo de usuário específico.</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id) 
        {
            return Ok(_tiposUsuarioRepository.BuscarPorId(id));
        }
    }
}
