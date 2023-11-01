using webapi.healthclinic.manha.Domains;

namespace webapi.healthclinic.manha.Interfaces
{
    public interface IMedicoRepository
    {
        void Cadastrar(Medico medico);

        void Deletar(Guid id);
        List<Medico> Listar();
        Medico BuscarPorId(Guid id);
    }
}
