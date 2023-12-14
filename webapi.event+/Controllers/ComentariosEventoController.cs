﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.CognitiveServices.ContentModerator;
using System.Text;
using webapi.event_.Domains;
using webapi.event_.Repositories;

namespace webapi.event_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ComentariosEventoController : ControllerBase
    {
        ComentariosEventoRepository comentario = new ComentariosEventoRepository();

        //Inicio da configuração do Controller para IA

        //armazena dados de serviço da API externa(IA - Azure)
        private readonly ContentModeratorClient _contentModeratorClient;

        /// <summary>
        /// Construtor que recebe os dados necessários para acesso ao serviço externo
        /// </summary>
        /// <param name="contentModeratorClient">objeto do tipo ContentModeratorClient</param>
        public ComentariosEventoController(ContentModeratorClient contentModeratorClient)
        {
            _contentModeratorClient = contentModeratorClient;
        }

        [HttpPost("ComentarioIA")]
        public async Task<IActionResult> PostIA(ComentariosEvento novoComentario)
        {
            try
            {
                //if (comentario.Descricao != null || comentario.Descricao == "")
                if(string.IsNullOrEmpty(novoComentario.Descricao)) 
                {
                    return BadRequest("A descricao do comentario nao pode estar vazio ou nulo");
                }

                using var stream = new MemoryStream(Encoding.UTF8.GetBytes(novoComentario.Descricao));

                var moderationResult = await _contentModeratorClient.TextModeration
                    .ScreenTextAsync("text/plain", stream, "por", false, false, null,true);

                if (moderationResult.Terms != null)
                {
                    novoComentario.Exibe = false;

                   comentario.Cadastrar(novoComentario);        
                }
                else
                {
                    novoComentario.Exibe= true;

                    comentario.Cadastrar(novoComentario);
                }
                return StatusCode(201, novoComentario);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet]
        public IActionResult get()
        {
            try
            {
                return Ok(comentario.Listar());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("ListarSomenteExibe")]
        public IActionResult GetShow()
        {
            try
            {
                return Ok(comentario.ListarSomenteExibe());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet("BuscarPorIdUsuario/{idUsuario}/{idEvento}")]
        public IActionResult GetbyIdUser(Guid idUsuario, Guid idEvento)
        {
            try
            {
                return Ok(comentario.BuscarPorIdUsuario(idUsuario, idEvento));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("BuscarPorIdEvento/{idEvento}")]
        public IActionResult GetbyIdEvent(Guid idEvento)
        {
            try
            {
                return Ok(comentario.BuscarPorIdEvento(idEvento));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        } [HttpGet("BuscarPorIdEvento/{idEvento}")]


        public IActionResult GetbyIdEventExibe(Guid idEvento)
        {
            try
            {
                return Ok(comentario.BuscarPorIdEventoExibe(idEvento));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpPost]
        public IActionResult Post(ComentariosEvento novoComentario)
        {
            try
            {
                comentario.Cadastrar(novoComentario);

                return StatusCode(201, novoComentario);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("(id)")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                comentario.Deletar(id);

                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}

