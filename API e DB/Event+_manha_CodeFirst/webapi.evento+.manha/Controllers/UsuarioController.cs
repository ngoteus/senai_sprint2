﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.evento_.manha.Domains;
using webapi.evento_.manha.Interfaces;
using webapi.evento_.manha.Repositories;
using webapi.evento_.manha.Utils;

namespace webapi.evento_.manha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class UsuarioController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository;

        public UsuarioController() 
        {
            _usuarioRepository = new UsuarioRepository();
        }
        [HttpPost]
        public IActionResult Post(Usuario usuario)
        {
            try
            {
                _usuarioRepository.Cadastrar(usuario);

                return StatusCode(201);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]

        public IActionResult GetById(Guid id)
        {
            Usuario usuarioBuscado = new Usuario();

            try
            {
                return Ok(_usuarioRepository.BuscarPorId(id));
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
        
        //[HttpGet]

        //public IActionResult Cadastrar(Usuario usuario) 
        //{
        //    try
        //    {
        //        _usuarioRepository.Cadastrar(usuario);

        //                return Ok();
        //    }
        //    catch (Exception e)
        //    {
        //        return BadRequest(e.Message);
        //    }
            
        //}
    }
}
