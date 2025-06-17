using System.ComponentModel.DataAnnotations;

namespace TurismoApp.Models
{
    public class CidadeDestino
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome da cidade é obrigatório.")]
        [MinLength(3, ErrorMessage = "O nome da cidade deve ter ao menos 3 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O país é obrigatório.")]
        [MinLength(3, ErrorMessage = "O nome do país deve ter ao menos 3 caracteres.")]
        public string Pais { get; set; }
    }
}
