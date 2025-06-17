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

        public List<Destino> Destinos { get; set; } = new();
        public List<Reserva> Reservas { get; set; } = new();

        // Evento que será disparado quando a capacidade for atingida
        public event Action<string>? CapacityReached;

        // Método para adicionar reserva e disparar o evento se necessário
        public void AdicionarReserva(Reserva reserva)
        {
            if (Reservas.Count >= CapacidadeMaxima)
            {
                CapacityReached?.Invoke($"⚠️ Capacidade máxima atingida para o pacote \"{Titulo}\".");
                return;
            }

            Reservas.Add(reserva);

            if (Reservas.Count == CapacidadeMaxima)
            {
                CapacityReached?.Invoke($"⚠️ Última vaga preenchida para o pacote \"{Titulo}\".");
            }
        }
    }
}
