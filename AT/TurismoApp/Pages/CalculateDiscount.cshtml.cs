using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TurismoApp.Pages
{
    public class CalculateDiscountModel : PageModel
    {
        [BindProperty]
        public decimal Price { get; set; }

        public decimal? DiscountedPrice { get; set; }

        public void OnPost()
        {
            DiscountedPrice = Price * 0.9m;
        }
    }
}
