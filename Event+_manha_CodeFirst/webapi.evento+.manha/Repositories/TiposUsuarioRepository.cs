using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using webapi.evento_.manha.Context;
using webapi.evento_.manha.Domains;
using webapi.evento_.manha.Interfaces;

namespace webapi.evento_.manha.Repositories
{
    public class TiposUsuarioRepository : ITiposUsuarioRepository
    {
        private readonly EventContext _eventContext;

        public TiposUsuarioRepository() 
        {
            _eventContext= new EventContext();
        }

        public void Atualizar(Guid id, TiposUsuario tipoUsuario)
        {
            TiposUsuario tiposUsuario1 = _eventContext.TiposUsuarios.Find(id)!;

            if (tiposUsuario1 != null)
            {
                tiposUsuario1.Titulo = tiposUsuario1.Titulo;
            }

            _eventContext.TiposUsuarios.Update(tiposUsuario1!);

            _eventContext.SaveChanges();
        }

        public TiposUsuario BuscarPorId(Guid id)
        {
            return _eventContext.TiposUsuarios.FirstOrDefault(e => e.IdTipoUsuario == id)!;
        }

        public void Cadastrar(TiposUsuario tipoUsuario)
        {
            _eventContext.TiposUsuarios.Add(tipoUsuario);

            _eventContext.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            TiposUsuario tiposUsuario = _eventContext.TiposUsuarios.Find(id)!;

            _eventContext.SaveChanges();
        }

        public List<TiposUsuario> Listar()
        {
            return _eventContext.TiposUsuarios.Include(e => e.Titulo).ToList();
        }
    }
}
