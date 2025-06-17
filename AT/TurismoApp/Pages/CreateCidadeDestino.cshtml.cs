using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TurismoApp.Models;
using TurismoApp.Data;

namespace TurismoApp.Pages
{
    public class CreateCidadeDestinoModel : PageModel
    {
        private readonly AppDbContext _context;

        public CreateCidadeDestinoModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CidadeDestino CidadeDestino { get; set; }

        public IActionResult OnGet()
        {
            // Verifica se o usuário está logado antes de mostrar a página
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("UsuarioLogado")))
            {
                return RedirectToPage("Login");
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("UsuarioLogado")))
            {
                return RedirectToPage("Login");
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.CidadesDestino.Add(CidadeDestino);
            _context.SaveChanges();

            return RedirectToPage("/Index"); // redireciona para página inicial ou outra
        }
    }
}
