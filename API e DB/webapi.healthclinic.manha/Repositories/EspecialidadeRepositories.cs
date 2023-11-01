using Microsoft.EntityFrameworkCore;
using webapi.healthclinic.manha.Context;
using webapi.healthclinic.manha.Domains;
using webapi.healthclinic.manha.Interfaces;

namespace webapi.healthclinic.manha.Repositories
{
    public class EspecialidadeRepositories : IEspecialidadeRepository
    {
        private readonly HealthClinicContext _healthClinicContext;
        public EspecialidadeRepositories()
        {
            _healthClinicContext= new HealthClinicContext();
        }
        public Especialidade BuscarPorId(Guid id) 
        {
            return _healthClinicContext.Especialidade.FirstOrDefault(e => e.IdEspecialdiade == id)!;
        }
        public void Cadastrar(Especialidade especialidade) 
        {
            _healthClinicContext.Especialidade.Add(especialidade);
            _healthClinicContext.SaveChanges();
        }
        public void Deletar(Guid id)
        {
            _healthClinicContext.Especialidade.Where(e => e.IdEspecialdiade == id).ExecuteDelete();
        }

        public List<Especialidade> Listar()
        {
            return _healthClinicContext.Especialidade.ToList();
        }
    }
}
