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
    public class JogosController : ControllerBase
    {
        
            private IJogosRepository _jogosRepository { get; set; }

            public JogosController()
            {
                _jogosRepository = new JogosRepository();
            }

            /// <summary>
            /// EndPoint que lista todos os jogos existentes
            /// </summary>
            /// <returns>retorna uma lista com todos os jogos e o status code</returns>
            /// 

            [HttpGet]

            public IActionResult Get()
            {
                //_jogosRepository.ListarTodos();

                try
                {
                    List<JogosDomain> listaJogos = _jogosRepository.ListarTodos();

                    return Ok(listaJogos);
                }
                catch (Exception erro)
                {

                    return BadRequest(erro.Message);
                }



            }

            [HttpPost]

            public IActionResult Create(JogosDomain jogo)
            {
                try
                {
                    _jogosRepository.Cadastrar(jogo);

                    return Ok(jogo);
                }
                catch (Exception erro)
                {
                    return BadRequest(erro.Message);
                };
            }


        
    }
}
