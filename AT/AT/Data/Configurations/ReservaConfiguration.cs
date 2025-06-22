using AT.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AT.Data.Configurations
{
    public class ReservaConfiguration : IEntityTypeConfiguration<Reserva>
    {
        public void Configure(EntityTypeBuilder<Reserva> builder)
        {
            builder.HasData(
                new Reserva
                {
                    Id = 1,
                    ClienteId = 1,
                    PacoteTuristicoId = 2,
                    DataReserva = new DateTime(2025, 7, 1)
                },
                new Reserva
                {
                    Id = 2,
                    ClienteId = 2,
                    PacoteTuristicoId = 1,
                    DataReserva = new DateTime(2025, 7, 5)
                },
                new Reserva
                {
                    Id = 3,
                    ClienteId = 3,
                    PacoteTuristicoId = 3,
                    DataReserva = new DateTime(2025, 8, 12)
                },
                new Reserva
                {
                    Id = 4,
                    ClienteId = 4,
                    PacoteTuristicoId = 5,
                    DataReserva = new DateTime(2025, 9, 3)
                },
                new Reserva
                {
                    Id = 5,
                    ClienteId = 5,
                    PacoteTuristicoId = 4,
                    DataReserva = new DateTime(2025, 10, 20)
                }
            );
        }
    }
}
