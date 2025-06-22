using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AT.Pages.NewPages
{
    public class ViewNotesModel : PageModel
    {
        public List<string> FileNames { get; set; } = new List<string>();
        public string? FileContent { get; set; }
        public string? SelectedFileName { get; set; }

        public void OnGet(string? filename)
        {
            string folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "files");

            // Garante que o diretório existe
            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);

            // Lista os arquivos
            FileNames = Directory.GetFiles(folderPath, "*.txt")
                                 .Select(Path.GetFileName)
                                 .ToList();

            // Se o usuário clicou em um arquivo
            if (!string.IsNullOrEmpty(filename))
            {
                string fullPath = Path.Combine(folderPath, filename);
                if (System.IO.File.Exists(fullPath))
                {
                    SelectedFileName = filename;
                    FileContent = System.IO.File.ReadAllText(fullPath);
                }
            }
        }
    }
}
