using Microsoft.EntityFrameworkCore;
using webapi.healthclinic.manha.Context;
using webapi.healthclinic.manha.Domains;
using webapi.healthclinic.manha.Interfaces;

namespace webapi.healthclinic.manha.Repositories
{
    public class MedicoRepositories : IMedicoRepository
    {
        private readonly HealthClinicContext _healthClinicContext;
        public MedicoRepositories()
        {
               _healthClinicContext= new HealthClinicContext();
        }
        public Medico BuscarPorId(Guid id) 
        {
            return _healthClinicContext.Medico.FirstOrDefault(e => e.IdMedico == id)!;
        }

        public void Cadastrar(Medico medico) 
        {
            _healthClinicContext.Medico.Add(medico);

            _healthClinicContext.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            _healthClinicContext.Medico.Where(e => e.IdMedico == id).ExecuteDelete();
        }

        public List<Medico> Listar()
        {
            return _healthClinicContext.Medico.ToList();
        }
    }
}
