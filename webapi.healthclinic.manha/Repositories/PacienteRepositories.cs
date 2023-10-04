using Microsoft.EntityFrameworkCore;
using webapi.healthclinic.manha.Context;
using webapi.healthclinic.manha.Domains;
using webapi.healthclinic.manha.Interfaces;

namespace webapi.healthclinic.manha.Repositories
{
    public class PacienteRepositories : IPacienteRepository
    {
        private readonly HealthClinicContext _healthClinicContext;

        public PacienteRepositories()
        {
            _healthClinicContext = new HealthClinicContext();
        }
        public void Cadastrar(Paciente paciente) 
        {
            _healthClinicContext.Paciente.Add(paciente);
            _healthClinicContext.SaveChanges();
        }
        public void Deletar(Guid id)
        {
            _healthClinicContext.Paciente.Where(e => e.IdPacientes == id).ExecuteDelete();
        }
        public Paciente BuscarPorId(Guid id) 
        {
            return _healthClinicContext.Paciente.FirstOrDefault(e => e.IdPacientes == id)!;
        }
        public List<Paciente> Listar()
        {
            return _healthClinicContext.Paciente.ToList();
        }
    }
}
