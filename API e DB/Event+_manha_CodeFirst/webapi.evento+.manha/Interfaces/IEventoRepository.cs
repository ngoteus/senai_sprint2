using webapi.evento_.manha.Domains;

namespace webapi.evento_.manha.Interfaces
{
    public interface IEventoRepository
    {
            void Cadastrar(Evento evento);
            void Deletar(Guid id);
            List<Evento> Listar();
            Evento BuscarPorId(Guid id);
            void Atualizar(Guid id, Evento evento);
        
    }
}
