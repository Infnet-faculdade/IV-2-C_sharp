using AT.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AT.Data.Configurations
{
    public class DestinoConfiguration : IEntityTypeConfiguration<Destino>
    {
        public void Configure(EntityTypeBuilder<Destino> builder)
        {
            builder.HasData(
                new Destino { Id = 1, Nome = "Coliseu", Pais = "Itália" },
                new Destino { Id = 2, Nome = "Acrópole", Pais = "Grécia" },
                new Destino { Id = 3, Nome = "Torre Eiffel", Pais = "França" },
                new Destino { Id = 4, Nome = "Machu Picchu", Pais = "Peru" },
                new Destino { Id = 5, Nome = "Grand Canyon", Pais = "Estados Unidos" }
            );
        }
    }
}
