using webapi.healthclinic.manha.Domains;

namespace webapi.healthclinic.manha.Interfaces
{
    public interface IComentarioRepository
    {
        void Cadastrar(Comentario comentario);

        void Deletar(Guid id);
        List<Comentario> Listar();
        Comentario BuscarPorId(Guid id);
    }
}
