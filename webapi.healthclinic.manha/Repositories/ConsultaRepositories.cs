using Microsoft.EntityFrameworkCore;
using webapi.healthclinic.manha.Context;
using webapi.healthclinic.manha.Domains;
using webapi.healthclinic.manha.Interfaces;

namespace webapi.healthclinic.manha.Repositories
{
    public class ConsultaRepositories : IConsultaRepository
    {
        private readonly HealthClinicContext _healthClinicContext;
        public ConsultaRepositories()
        {
            _healthClinicContext= new HealthClinicContext();
        }
        public Consulta BuscarPorId (Guid id) 
        {
            return _healthClinicContext.Consulta.FirstOrDefault(e => e.IdConsulta == id)!;
        }

        public void Cadastrar(Consulta consulta) 
        {
            _healthClinicContext.Consulta.Add(consulta);

            _healthClinicContext.SaveChanges();
        }
        public void Deletar(Guid id) 
        {
            _healthClinicContext.Consulta.Where(e => e.IdConsulta == id).ExecuteDelete();
        }
        public List<Consulta> Listar()
        {
            return _healthClinicContext.Consulta.ToList();
        }
    }
}
