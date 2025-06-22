using AT.Data.Configurations;
using AT.Models;
using Microsoft.EntityFrameworkCore;

namespace AT.Data
{
    public class ATContext : DbContext
    {
        public ATContext() { }

        public ATContext(DbContextOptions<ATContext> options) : base(options) { }

        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Destino> Destinos { get; set; }
        public virtual DbSet<PacoteTuristico> PacotesTuristicos { get; set; }
        public virtual DbSet<Reserva> Reservas { get; set; }
        public virtual DbSet<Endereco> Enderecos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
    
            modelBuilder.Entity<PacoteTuristico>()
                        .Property(p => p.Preco)
                        .HasPrecision(18, 2);

            modelBuilder.ApplyConfiguration(new ClienteConfiguration());
            modelBuilder.ApplyConfiguration(new DestinoConfiguration());
            modelBuilder.ApplyConfiguration(new PacoteTuristicoConfiguration());
            modelBuilder.ApplyConfiguration(new ReservaConfiguration());
            modelBuilder.ApplyConfiguration(new EnderecoConfiguration());
        }
    }
}
