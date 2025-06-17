using System;
using System.Collections.Generic;

namespace TurismoApp.Models
{
    public class PacoteTuristico
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public DateTime DataInicio { get; set; }
        public int CapacidadeMaxima { get; set; }
        public decimal Preco { get; set; }
        public List<Destino> Destinos { get; set; } = new List<Destino>();

        public List<Reserva> Reservas { get; set; } = new List<Reserva>();

        // Delegate do evento CapacityReached
        public delegate void CapacityReachedHandler(object sender, EventArgs e);

        // Evento disparado quando a capacidade é atingida
        public event CapacityReachedHandler? CapacityReached;

        // Método para adicionar reserva
        public void AdicionarReserva(Reserva reserva)
        {
            if (Reservas.Count >= CapacidadeMaxima)
            {
                // Capacidade atingida, dispara evento
                CapacityReached?.Invoke(this, EventArgs.Empty);
                return; // não adiciona reserva se a capacidade já foi atingida
            }

            Reservas.Add(reserva);

            if (Reservas.Count == CapacidadeMaxima)
            {
                CapacityReached?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}
