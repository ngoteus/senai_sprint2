using webapi.evento_.manha.Context;
using webapi.evento_.manha.Domains;
using webapi.evento_.manha.Interfaces;

namespace webapi.evento_.manha.Repositories
{
    public class ComentariosEventoRepository
    {
        public class ComentariosEventoRepository : IComentariosEventoRepository
        {
            private readonly EventContext _context;

            public ComentariosEventoRepository()
            {
                _context = new EventContext();
            }

            public ComentariosEvento BuscarPorId(Guid id)
            {
                try
                {
                    return _context.ComentariosEvento
                        .Select(c => new ComentariosEvento
                        {
                            Descricao = c.Descricao,
                            Exibe = c.Exibe,

                            Usuario = new Usuario
                            {
                                Nome = c.Usuario!.Nome
                            },

                            Evento = new Evento
                            {
                                NomeEvento = c.Evento!.NomeEvento,
                            }

                        }).FirstOrDefault(c => c.IdComentarioEvento == id)!;
                }
                catch (Exception)
                {
                    throw;
                }
            }

            public void Cadastrar(ComentariosEvento comentarioEvento)
            {
                try
                {
                    _context.ComentariosEvento.Add(comentarioEvento);
                }
                catch (Exception)
                {
                    throw;
                }
            }

            public void Deletar(Guid id)
            {
                try
                {
                    ComentariosEvento comentarioEventoBuscado = _context.ComentariosEvento.Find(id)!;

                    if (comentarioEventoBuscado != null)
                    {
                        _context.ComentariosEvento.Remove(comentarioEventoBuscado);
                    }

                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }

            public List<ComentariosEvento> Listar()
            {

                try
                {
                    return _context.ComentariosEvento
                        .Select(c => new ComentariosEvento
                        {
                            Descricao = c.Descricao,
                            Exibe = c.Exibe,

                            Usuario = new Usuario
                            {
                                Nome = c.Usuario!.Nome
                            },

                            Evento = new Evento
                            {
                                NomeEvento = c.Evento!.NomeEvento,
                            }

                        }).ToList();
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
    }
}
