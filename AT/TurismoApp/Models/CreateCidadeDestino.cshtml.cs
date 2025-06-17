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

		public void OnGet()
		{
			// Apenas carrega a página
		}

		public IActionResult OnPost()
		{
			if (!ModelState.IsValid)
			{
				return Page();
			}

			_context.CidadesDestino.Add(CidadeDestino);
			_context.SaveChanges();

			return RedirectToPage("/Index"); // ou outra página que preferir
		}
	}
}

