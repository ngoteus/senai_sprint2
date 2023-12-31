﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using webapi.filmes.manha.Domains;
using webapi.filmes.manha.Interfaces;
using webapi.filmes.manha.Repositories;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace webapi.filmes.manha.Controllers
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
    [Authorize]

    public class GeneroController : ControllerBase
    {
        /// <summary>
        /// Objeto _generoRepository que ira receber todos os metodos definidos na interface IGeneroRepository
        /// </summary>
        private IGeneroRepository _generoRepository { get; set; }

        public GeneroController()
        {
            _generoRepository = new GeneroRepository();
        }

        //EndPoint que aciona o metodo ListarTodos no repositorio e retorna a resposta para o usuario(front-end)
        [HttpGet]
        
        public IActionResult Get()
        {
            try
            {
                //Cria uma lista que recebe os dados da requisicao
                List<GeneroDomain> listaGeneros = _generoRepository.ListarTodos();

                //Retorna a lista no formato JSON com o status code Ok(200)
                return Ok(listaGeneros);
            }
            catch (Exception erro)
            {
                //Retorna um status code BadRequest(400) e a mensagem do erro
                return BadRequest(erro.Message);
            }

        }
        /// <summary>
        /// Endpoint que aciona o metodo de cadastro de genero
        /// </summary>
        /// <param name="novoGenero">Objeto recebido na requisicao</param>
        /// <returns>status code 201(created)</returns>

        [HttpPost]
        [Authorize(Roles = "True" )]
        public IActionResult Post(GeneroDomain novoGenero)
        {
            try
            {

                //Fazendo a chamada para o metodo cadastrar passando o objeto como parametro
                _generoRepository.Cadastrar(novoGenero);

                //retorna um status code 201 - Created
                return StatusCode(201);
            }
            catch (Exception erro)
            {
                //Retorna um status code BadRequest(400) e a mensagem do err
                return BadRequest(erro.Message);
            }


        }

        [HttpDelete]
        [Authorize(Roles = "True")]
        public IActionResult Delete(int id)
        {
            try
            {
                _generoRepository.Deletar(id);

                return StatusCode(204);
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }

        [HttpGet("{id}")]
        [Authorize (Roles = "True")]
        public IActionResult GetById(int id)
        {
            try
            {
                GeneroDomain generoBuscado = _generoRepository.BuscarPorId(id);

                if (generoBuscado == null)
                {
                    return NotFound("Nenhum genero foi encontrado!");
                }

                return Ok(generoBuscado);
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }

        }





        [HttpPut]
        [Authorize(Roles = "True")]
        public IActionResult PutIdBody(GeneroDomain genero)
        {
            try
            {
                GeneroDomain generoBuscado = _generoRepository.BuscarPorId(genero.IdGenero);

                if (generoBuscado != null)
                {
                    try
                    {
                        _generoRepository.AtualizarIdCorpo(genero);
                        return Ok();
                    }
                    catch (Exception erro)
                    {

                        return BadRequest(erro.Message);
                    }
                    //return NotFound("Geenero nao encontrado!");
                }

                return NotFound("Geenero nao encontrado!");

            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }


        }

        [HttpPut("{id}")]
        [Authorize(Roles = "True")]
        public IActionResult PutIdUrl(int id, GeneroDomain genero)
        {
            GeneroDomain generoBuscado = _generoRepository.BuscarPorId(id);
            try
            {
                if (generoBuscado != null)
                {
                    try
                    {
                        _generoRepository.AtualizarIdUrL(id, genero);
                         return Ok();
                    }
                    catch (Exception erro)
                    {

                        return BadRequest(erro.Message);
                    }
                    
                }
                throw new Exception();
            }
            catch
            {
                return NotFound("Genero nao encontrado!");
            }
            
        }

        //[HttpPut]
        //public IActionResult PutIdUrl
    }

}
