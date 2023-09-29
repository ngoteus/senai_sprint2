using Microsoft.EntityFrameworkCore;
using webapi.healthclinic.manha.Context;
using webapi.healthclinic.manha.Domains;
using webapi.healthclinic.manha.Interfaces;
using webapi.healthclinic.manha.Repositories;

namespace webapi.healthclinic.manha.Repositories
{
    public class ClinicaRepositories : IClinicaRepository
    {
        private readonly HealthClinicContext _healthClinicContext;

        public ClinicaRepositories()
        {
            _healthClinicContext = new HealthClinicContext();
        }
        public Clinica BuscarPorId(Guid id)
        {
            return _healthClinicContext.Clinica.FirstOrDefault(e => e.IdClinica == id)!;
        }

        public void Cadastrar(Clinica clinica)
        {
            _healthClinicContext.Clinica.Add(clinica);

            _healthClinicContext.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            _healthClinicContext.Clinica.Where(e => e.IdClinica == id).ExecuteDelete();
        }

        //public List<Clinica> Listar()
        //{
        //    return _healthClinicContext.Clinica.Include
        //}
    }
}
