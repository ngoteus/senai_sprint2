using Microsoft.EntityFrameworkCore;
using webapi.healthclinic.manha.Context;
using webapi.healthclinic.manha.Domains;
using webapi.healthclinic.manha.Interfaces;

namespace webapi.healthclinic.manha.Repositories
{
    public class ComentariosRepositories : IComentarioRepository
    {
        private readonly HealthClinicContext _healthClinicContext;
        public ComentariosRepositories()
        {
            _healthClinicContext= new HealthClinicContext();
        }
        public Comentario BuscarPorId(Guid id)
        {
            return _healthClinicContext.Comentario.FirstOrDefault(e => e.IdComentario == id)!;
        }

        public void Cadastrar(Comentario comentario)
        {
          _healthClinicContext.Comentario.Add(comentario);

            _healthClinicContext.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            _healthClinicContext.Comentario.Where(e => e.IdComentario == id).ExecuteDelete();
        }

        public List<Comentario> Listar()
        {
           return _healthClinicContext.Comentario.ToList();
        }
    }
}
