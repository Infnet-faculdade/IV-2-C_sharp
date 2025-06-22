using AT.Data;
using AT.Models;
using AT.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AT.Pages.NewPages
{
    public class CreateDestinoModel : PageModel
    {
        private readonly IService _service;
        private readonly ATContext _context;
        public int? Id { get; set; } // Retorno do cadeastro

        public CreateDestinoModel(ATContext context, IService service)
        {
            _service = service;
            _context = context;
        }

        [BindProperty]        
        public Destino Destino { get; set; } = new Destino();
        public List<Destino> Destinos{ get; set; } = new();

        public async Task OnGetAsync()
        {
            Destinos = await _service.GetAllAsyncDestino();
        }

        public async Task<IActionResult> OnPostDestinoAsync()
        {
            if (!ModelState.IsValid)
            {
                // Volta para a página para mostrar erros
                Destinos = await _service.GetAllAsyncDestino();
                return Page();
            }

            await _context.Destinos.AddAsync(Destino);
            await _context.SaveChangesAsync();
            
            Id = Destino.Id;
            Destino = new Destino();            

            // Recarrega a página
            Destinos = await _service.GetAllAsyncDestino();

            return Page();
        }
    }
}
