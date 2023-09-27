using Microsoft.EntityFrameworkCore;
using webapi.healthclinic.manha.Domains;

namespace webapi.healthclinic.manha.Context
{
    public class HealthClinicContext : DbContext
    {
        public DbSet<TiposUsuario> TiposUsuarios { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Clinica> Clinica { get; set; }
        public DbSet<Medico> Medicos { get; set; }
        public DbSet<Comentario> Comentario { get; set; }
        public DbSet<Consulta> Consulta { get; set; }
        public DbSet<Paciente> Paciente { get; set; }
        public DbSet<Especialidade> Especialidade { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=NOTE04-S14; Database=webapi.healthclinic.manha; User id = sa; pwd = Senai@134; TrustServerCertificate=True;");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
