using webapi.evento_.manha.Context;
using webapi.evento_.manha.Domains;

namespace webapi.evento_.manha.Repositories
{
    public class TiposEventoRepository
    {
        private readonly EventContext _eventContext;

        public TiposEventoRepository()
        {
            _eventContext= new EventContext();
        }  

        public void Atualizar(Guid id, TiposEvento tiposEvento) 
        {
            TiposEvento tipoEBuscado = _eventContext.TiposEvento.Find(id)!;

            if (tipoEBuscado != null)
            {
                tipoEBuscado.Titulo = tiposEvento.Titulo;
            }

            _eventContext.TiposEvento.Update(tipoEBuscado!);

            _eventContext.SaveChanges();
        }

        public TiposEvento BuscarPorId(Guid id) 
        {
            TiposEvento tiposEBuscado = _eventContext.TiposEvento.Find(id)!;

            return tiposEBuscado;
        }

        public void Cadastrar(TiposEvento tiposEvento) 
        {
            _eventContext.TiposEvento.Add(tiposEvento);

            _eventContext.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            TiposEvento tipo_E_Buscado = _eventContext.TiposEvento.Find(id)!;

            _eventContext.TiposEvento.Remove(tipo_E_Buscado);

            _eventContext.SaveChanges();
        }

        public List<TiposEvento> Listar()
        {
            return _eventContext.TiposEvento.ToList();
        }
    }
}
