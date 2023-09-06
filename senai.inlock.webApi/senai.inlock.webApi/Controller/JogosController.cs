using Microsoft.AspNetCore.Mvc;
using senai.inlock.webApi_.Interfaces;
using senai.inlock.webApi_.Domains;
using senai.inlock.webApi_.Repository;

namespace senai.inlock.webApi_.Controller
{
    //Define a rota de uma requisicao sera no seguinte formato
    //dominio/api/nomeController
    //ex : http://localhost:5000/api/genero
    [Route("api/[controller]")]

    //Define que e um controlador de api
    [ApiController]

    //Define que o tipo de resposta da api sera no formato JSON
    [Produces("application/json")]

    //Metodo controlador que herda da controller base
    //Onde sera criado os Endpoints(rotas)
    public class JogosController : ControllerBase
    {
        public IJogosRepository _jogosRepository { get; set; }
        
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
            _jogosRepository.ListarJogo();

            try
            {
                List<JogosDomain> listaJogos = _jogosRepository.ListarJogo();

            return Ok(listaJogos);
            }
            catch (Exception erro)
            {

                return BadRequest(erro.) ;
            }

            
        
        }

    }
}
