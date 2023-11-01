using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai.inlock.webApi_.Domains;
using senai.inlock.webApi_.Interfaces;
using senai.inlock.webApi_.Repository;

namespace senai.inlock.webApi_.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class EstudioController : ControllerBase
    {


        private IEstudioRepository _estudioRepository { get; set; }

        public EstudioController()
        {
            _estudioRepository = new EstudioRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            _estudioRepository.ListarTodos();
            try
            {
                List<EstudioDomain> listaEstudio = _estudioRepository.ListarTodos();

                return Ok(listaEstudio);
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
            
        }
        [HttpPost]
        public IActionResult Create(EstudioDomain novoEstudio) 
        {
            try
            {
                _estudioRepository.Cadastrar(novoEstudio);

                return StatusCode(201);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
                
            }
        }
    }
}

