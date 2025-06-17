using Microsoft.EntityFrameworkCore;
using TurismoApp.Models;

namespace TurismoApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Destino> Destinos { get; set; }
        public DbSet<PacoteTuristico> PacotesTuristicos { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
        public DbSet<CidadeDestino> CidadeDestino { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Relacionamento PacoteTuristico - Destinos (muitos para muitos)
            modelBuilder.Entity<PacoteTuristico>()
                .HasMany(p => p.Destinos)
                .WithMany();

            base.OnModelCreating(modelBuilder);
        }
    }
}
