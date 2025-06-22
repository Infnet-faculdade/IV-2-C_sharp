using AT.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AT.Data.Configurations
{
    public class PacoteTuristicoConfiguration : IEntityTypeConfiguration<PacoteTuristico>
    {
        public void Configure(EntityTypeBuilder<PacoteTuristico> builder)
        {
            builder.HasData(
                new PacoteTuristico
                {
                    Id = 1,
                    Titulo = "Descubra Roma",
                    DataInicio = new DateTime(2025, 7, 10),
                    Preco = 1200.50m,
                    CapacidadeMaxima = 25
                },
                new PacoteTuristico
                {
                    Id = 2,
                    Titulo = "Encantos da Grécia",
                    DataInicio = new DateTime(2025, 8, 5),
                    Preco = 1500.00m,
                    CapacidadeMaxima = 20
                },
                new PacoteTuristico
                {
                    Id = 3,
                    Titulo = "Paris Romântica",
                    DataInicio = new DateTime(2025, 9, 15),
                    Preco = 1800.75m,
                    CapacidadeMaxima = 30
                },
                new PacoteTuristico
                {
                    Id = 4,
                    Titulo = "Aventura nos Andes",
                    DataInicio = new DateTime(2025, 10, 1),
                    Preco = 2200.99m,
                    CapacidadeMaxima = 15
                },
                new PacoteTuristico
                {
                    Id = 5,
                    Titulo = "Explorando o Oeste Americano",
                    DataInicio = new DateTime(2025, 11, 20),
                    Preco = 2000.00m,
                    CapacidadeMaxima = 18
                }
            );
        }
    }
}
