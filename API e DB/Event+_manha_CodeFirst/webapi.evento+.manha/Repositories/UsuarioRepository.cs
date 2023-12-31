﻿using Microsoft.EntityFrameworkCore;
using webapi.evento_.manha.Context;
using webapi.evento_.manha.Domains;
using webapi.evento_.manha.Interfaces;
using webapi.evento_.manha.Utils;

namespace webapi.evento_.manha.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly EventContext _eventContext;

        public UsuarioRepository() 
        {
            _eventContext= new EventContext();
        }

        public Usuario BuscarPorEmailESenha(string email, string senha)
        {
            try
            {
                Usuario usuarioBuscado = _eventContext.Usuario
                    .Select(u => new Usuario
                    {
                        IdUsuario = u.IdUsuario,
                        Nome = u.Nome,
                        Email = u.Email,
                        Senha = u.Senha,
                        TiposUsuario = new TiposUsuario
                        {
                            IdTipoUsuario = u.IdTipoUsuario,
                            Titulo = u.TiposUsuario!.Titulo
                        }
                    }).FirstOrDefault(u => u.Email == email)!;

                if (usuarioBuscado != null)
                {
                    bool confere = Criptografia.CompararHash(senha, usuarioBuscado.Senha!);

                    if (confere)
                    {
                        return usuarioBuscado;
                    }
                }
                return null!;
            }
            catch (Exception)
            {
                throw;
            }
        }


        public Usuario BuscarPorId(Guid id)
        {
            try
            {
               Usuario usuarioBuscado = _eventContext.Usuario
               .Select(u => new Usuario
               { IdUsuario = u.IdUsuario,
                 Nome= u.Nome,
                 TiposUsuario= new TiposUsuario
                   {
                       Titulo = u.TiposUsuario!.Titulo
                   }
               }).FirstOrDefault(u => u.IdUsuario == id)!;
                if (usuarioBuscado != null)
                {
                    return usuarioBuscado;
                }
                return null!;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Cadastrar(Usuario usuario)
        {
            try
            {
                usuario.Senha = Criptografia.GerarHash(usuario.Senha!);

                _eventContext.Usuario.Add(usuario);

                _eventContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
