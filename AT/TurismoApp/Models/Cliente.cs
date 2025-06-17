using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TurismoApp.Models
{
    public class Cliente
    {
        public int Id { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "O nome deve ter no mínimo 3 caracteres.")]
        public string Nome { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "E-mail inválido.")]
        public string Email { get; set; }

        public List<Reserva> Reservas { get; set; } = new List<Reserva>();
    }
}
