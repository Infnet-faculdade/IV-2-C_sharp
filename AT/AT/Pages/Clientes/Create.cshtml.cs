using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AT.Data;
using AT.Models;

namespace AT.Pages.Clientes
{
    public class CreateModel : PageModel
    {
        private readonly ATContext _context;
        public int? Id { get; set; } // Retorno do cadeastro

        public CreateModel(ATContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Cliente Cliente { get; set; }

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)            
                return Page();

            // Salva o endereço do cliente
            if (Cliente.Endereco != null)
            {
                await _context.Enderecos.AddAsync(Cliente.Endereco);
                await _context.SaveChangesAsync();

                // Vincula o endereço ao cliente
                Cliente.EnderecoId = Cliente.Endereco.Id;
            }

            _context.Clientes.Add(Cliente);
            await _context.SaveChangesAsync();

            Id = Cliente.Id;
            // Limpa o formulário para novo cadastro
            Cliente = new Cliente();
            ModelState.Clear();


            return RedirectToPage("/Index");
        }
    }
}
