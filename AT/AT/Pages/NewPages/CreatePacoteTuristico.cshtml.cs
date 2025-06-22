using AT.Data;
using AT.Models;
using AT.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AT.Pages.NewPages
{
    public class CreatePacoteTuristicoModel : PageModel
    {
        private readonly IService _service;
        private readonly ATContext _context;
        public int? Id { get; set; } // Retorno do cadeastro

        public CreatePacoteTuristicoModel(ATContext context, IService service)
        {
            _service = service;
            _context = context;
        }

        [BindProperty]
        public PacoteTuristico PacoteTuristico { get; set; } = new ();
        public List<Destino>  destinos { get; set; } = new();
        public List<PacoteTuristico> PacotesTuristicos { get; set; } = new();

   
        public async Task OnGetAsync()
        {
            PacotesTuristicos = await _service.GetAllAsyncPacoteTuristico();
            PacoteTuristico.DataInicio = DateTime.Today;
        }

        public async Task<IActionResult> OnPosteAsync()
        {
            PacoteTuristico.Destinos = destinos;   
            //if (!ModelState.IsValid)
            //    return Page();

            // Adiciona os itens ao contexto em memória
            await _context.PacotesTuristicos.AddAsync(PacoteTuristico);
            // Salva as alterações no banco de dados
            await _context.SaveChangesAsync();

            Id = PacoteTuristico.Id;
            PacoteTuristico = new();            

            return Page();
        }
    }
}
