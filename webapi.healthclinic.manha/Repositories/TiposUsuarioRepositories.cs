using Microsoft.EntityFrameworkCore;
using webapi.healthclinic.manha.Context;
using webapi.healthclinic.manha.Domains;
using webapi.healthclinic.manha.Interfaces;

namespace webapi.healthclinic.manha.Repositories
{
    public class TiposUsuarioRepositories : ITiposUsuarioRepository
    {
        private readonly HealthClinicContext _healthClinicContext;

        public TiposUsuarioRepositories()
        {
            _healthClinicContext = new HealthClinicContext();
        }
        public TiposUsuario BuscarPorId(Guid id)
        {
            return _healthClinicContext.TiposUsuarios.FirstOrDefault(e => e.IdTipoUsuario == id)!;
        }

        public void Cadastrar(TiposUsuario tiposUsuario)
        {
            _healthClinicContext.TiposUsuarios.Add(tiposUsuario);

            _healthClinicContext.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            TiposUsuario tiposUsuario = _healthClinicContext.TiposUsuarios.Find(id)!;

            _healthClinicContext.SaveChanges();
        }

        public List<TiposUsuario> Listar()
        {
            return _healthClinicContext.TiposUsuarios.ToList();
        }
    }
}
