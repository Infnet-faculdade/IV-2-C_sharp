using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace TurismoApp.Pages
{
    public class CalculateDiscountModel : PageModel
    {
        [BindProperty]
        [Required(ErrorMessage = "Informe o preço.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "O preço deve ser maior que zero.")]
        public decimal? Price { get; set; }

        public decimal? DiscountedPrice { get; set; }

        public void OnGet() { }

        public void OnPost()
        {
            if (!ModelState.IsValid)
            {
                return;
            }

            DiscountedPrice = Price * 0.9m;
        }
    }
}
