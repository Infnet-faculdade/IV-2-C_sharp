using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;
using TurismoApp.Data;
using TurismoApp.Models;

namespace TurismoApp.Pages.Reservas
{
    public class CreateModel : PageModel
    {
        private readonly AppDbContext _context;
        public CreateModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Reserva Reserva { get; set; } = new();

        public SelectList Clientes { get; set; }
        public SelectList Pacotes { get; set; }

        public void OnGet()
        {
            Clientes = new SelectList(_context.Clientes, "Id", "Nome");
            Pacotes = new SelectList(_context.PacotesTuristicos, "Id", "Titulo");
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            _context.Reservas.Add(Reserva);
            await _context.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}
