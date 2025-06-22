using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace AT.Pages.NewPages
{
    public class SaveNoteModel : PageModel
    {
        [BindProperty]
        public InputModel Input { get; set; } = new InputModel();

        public string? FileName { get; set; }

        public void OnPost(string action)
        {
            if (action == "clear")
            {
                Input = new InputModel();
                ModelState.Clear();

                return;
            }

            if (!ModelState.IsValid)
                return;

            string folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "files");

            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);

            FileName = $"note-{DateTime.Now:yyyyMMddHHmmss}.txt";
            string fullPath = Path.Combine(folderPath, FileName);

            System.IO.File.WriteAllText(fullPath, Input.Content);
        }

        public class InputModel
        {
            [Required(ErrorMessage = "O conteúdo da nota é obrigatório.")]
            public string Content { get; set; } = string.Empty;
        }
    }
}