using System.ComponentModel.DataAnnotations;

namespace AT.Models
{
    public class Endereco
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "O logradouro é obrigatório.")]        
        public string Rua { get; set; } = string.Empty;

        [Required(ErrorMessage = "A cidade é obrigatória.")]        
        public string Cidade { get; set; } = string.Empty;
    }
}
