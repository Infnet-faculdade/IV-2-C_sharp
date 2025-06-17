using System;
using System.Collections.Generic;

namespace TurismoApp.Models
{
    public class PacoteTuristico
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public DateTime DataInicio { get; set; }
        public int CapacidadeMaxima { get; set; }
        public decimal Preco { get; set; }
        public List<Reserva> Reservas { get; set; } = new();

        // Evento personalizado
        public event EventHandler CapacityReached;

        public void AdicionarReserva(Reserva reserva)
        {
            if (Reservas.Count >= CapacidadeMaxima)
            {
                CapacityReached?.Invoke(this, EventArgs.Empty); // Dispara o evento
                return;
            }

            Reservas.Add(reserva);

            if (Reservas.Count == CapacidadeMaxima)
            {
                CapacityReached?.Invoke(this, EventArgs.Empty); // Dispara ao atingir a capacidade
            }
        }
    }
}
