using System.ComponentModel.DataAnnotations;

namespace TurismoApp.Models
{
    public class Destino
    {
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Pais { get; set; }
    }
}
