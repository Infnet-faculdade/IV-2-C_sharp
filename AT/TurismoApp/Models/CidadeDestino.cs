using System.ComponentModel.DataAnnotations;

namespace TurismoApp.Models
{
    public class CidadeDestino
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome da cidade � obrigat�rio.")]
        [MinLength(3, ErrorMessage = "O nome da cidade deve ter ao menos 3 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O pa�s � obrigat�rio.")]
        [MinLength(3, ErrorMessage = "O nome do pa�s deve ter ao menos 3 caracteres.")]
        public string Pais { get; set; }
    }
}
