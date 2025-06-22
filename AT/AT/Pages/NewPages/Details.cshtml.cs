using AT.Models;
using AT.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AT.Pages.NewPages
{
    public class DetailsModel : PageModel
    {
        private readonly IService _pacoteTuristicoService;

        public DetailsModel(IService cityService)
        {
            _pacoteTuristicoService = cityService;
        }

        public PacoteTuristico? PacoteTuristico { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            PacoteTuristico = await _pacoteTuristicoService.GetByIdAsync(id);

            if (PacoteTuristico == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
