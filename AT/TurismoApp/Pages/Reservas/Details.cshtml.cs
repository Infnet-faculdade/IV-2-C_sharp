using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TurismoApp.Data;
using TurismoApp.Models;

namespace TurismoApp.Pages.Reservas
{
    public class DetailsModel : PageModel
    {
        private readonly AppDbContext _context;
        public DetailsModel(AppDbContext context)
        {
            _context = context;
        }

        public Reserva Reserva { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Reserva = await _context.Reservas
                .Include(r => r.Cliente)
                .Include(r => r.PacoteTuristico)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (Reserva == null)
                return NotFound();

            return Page();
        }
    }
}
