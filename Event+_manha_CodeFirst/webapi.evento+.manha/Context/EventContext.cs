using Microsoft.EntityFrameworkCore;
using webapi.evento_.manha.Domains;

namespace webapi.evento_.manha.Context
{
    public class EventContext : DbContext
    {
        public DbSet<TiposUsuario> TiposUsuarios { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<TiposEvento> TiposEvento { get; set; }
        public DbSet<Evento> Evento { get; set; }
        public DbSet<ComentariosEvento> ComentariosEvento { get; set; }
        public DbSet<Instituicao> Instituicao { get; set; }
        public DbSet<PresencasEvento> PresencasEventos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=NOTE04-S14; Database=webapi.evento+.manha; User id = sa; pwd = Senai@134; TrustServerCertificate=True;");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
