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

        /// <summary>
        /// Adiciona um novo comentário.
        /// </summary>
        /// <param name="novoComentario">O comentário a ser adicionado.</param>
        /// <returns>Retorna um código de status indicando o resultado da operação.</returns>
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
        /// <summary>
        /// Recupera todos os comentários disponíveis.
        /// </summary>
        /// <returns>Retorna uma lista de comentários.</returns>
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
        /// <summary>
        /// Recupera um comentário específico com base em seu ID.
        /// </summary>
        /// <param name="id">O ID do comentário a ser recuperado.</param>
        /// <returns>Retorna o comentário especificado.</returns>
        [HttpGet("{id}")]

        public IActionResult GetById(Guid id) 
        {
            return Ok(_comentarioRepository.BuscarPorId(id));
        }
        /// <summary>
        /// Exclui um comentário específico com base em seu ID.
        /// </summary>
        /// <param name="id">O ID do comentário a ser excluído.</param>
        /// <returns>Retorna um código de status indicando o resultado da operação.</returns>
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
