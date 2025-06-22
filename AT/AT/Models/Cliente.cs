using System.ComponentModel.DataAnnotations;

namespace AT.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "O nome é obrigatório.")]
        public string Nome { get; set; } = string.Empty;
        [Required(ErrorMessage = "O email é obrigatório.")]
        public string Email { get; set; } = string.Empty;

        // Chave estrangeira
        public int? EnderecoId { get; set; }
        // Navegação
        public Endereco? Endereco { get; set; }

        // Lista de reservas associadas ao cliente
        public List<Reserva> Reservas { get; set; } = new();
    }
}
