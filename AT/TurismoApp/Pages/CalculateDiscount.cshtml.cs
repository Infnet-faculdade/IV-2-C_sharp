using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace TurismoApp.Pages
{
    public class CalculateDiscountModel : PageModel
    {
        [BindProperty]
        [Required(ErrorMessage = "O preço é obrigatório")]
        [Range(0.01, double.MaxValue, ErrorMessage = "O preço deve ser maior que zero")]
        public decimal? Price { get; set; }

        public decimal? DiscountedPrice { get; set; }

        public void OnGet()
        {
            // Inicialização se precisar
        }

        public void OnPost()
        {
            if (!ModelState.IsValid)
            {
                DiscountedPrice = null;
                return;
            }

            // Aplica 10% de desconto no preço informado
            DiscountedPrice = Price * 0.9m;
        }
    }
}
