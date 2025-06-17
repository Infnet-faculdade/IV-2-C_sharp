using System;
using System.ComponentModel.DataAnnotations;

namespace TurismoApp.Models
{
    public class Reserva
    {
        public int Id { get; set; }

        [Required]
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; } = null!;

        [Required]
        public int PacoteTuristicoId { get; set; }
        public PacoteTuristico PacoteTuristico { get; set; } = null!;

        [Required]
        public DateTime DataReserva { get; set; }
    }
}

