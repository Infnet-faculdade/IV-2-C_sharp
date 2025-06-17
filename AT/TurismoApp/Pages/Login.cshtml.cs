using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;

namespace TurismoApp.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public string Username { get; set; } = string.Empty;

        [BindProperty]
        public string Password { get; set; } = string.Empty;

        public string ErrorMessage { get; set; } = string.Empty;

        public void OnGet()
        {
            // Limpa a sessão ao abrir a tela de login
            HttpContext.Session.Clear();
        }

        public IActionResult OnPost()
        {
            if (Username == "admin" && Password == "123")
            {
                HttpContext.Session.SetString("UsuarioLogado", Username);
                return RedirectToPage("LogOperations");
            }

            ErrorMessage = "Usuário ou senha inválidos!";
            return Page();
        }
    }
}
