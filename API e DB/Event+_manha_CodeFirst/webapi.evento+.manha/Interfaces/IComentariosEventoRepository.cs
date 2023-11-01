using webapi.evento_.manha.Domains;

namespace webapi.evento_.manha.Interfaces
{
    
        public interface IComentariosEventoRepository
        {
            void Cadastrar(ComentariosEvento comentarioEvento);
            void Deletar(Guid id);
            List<ComentariosEvento> Listar();
            ComentariosEvento BuscarPorId(Guid id);
        
        }
}
