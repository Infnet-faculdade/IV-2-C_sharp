using System;
using System.ComponentModel.DataAnnotations;

namespace TurismoApp.Models
{
    public class Reserva
    {
        public int Id { get; set; }

        [Required]
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        [Required]
        public int PacoteTuristicoId { get; set; }
        public PacoteTuristico PacoteTuristico { get; set; }

        [Required]
        public DateTime DataReserva { get; set; }
    }
}
