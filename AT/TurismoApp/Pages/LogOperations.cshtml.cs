using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TurismoApp.Pages
{
    public class LogOperationsModel : PageModel
    {
        [BindProperty]
        [Required(ErrorMessage = "Informe a mensagem do log")]
        public string LogMessage { get; set; } = string.Empty;  // inicializado para evitar warning

        // Lista para armazenar logs em memória durante a execução
        public static List<string> MemoryLogList { get; set; } = new();

        public List<string> MemoryLogs => MemoryLogList;

        // Delegate Action<string> multicast para logs
        private Action<string> LogDelegate { get; set; } = delegate { }; // inicializado para evitar warning

        public void OnGet()
        {
            // Configura o multicast delegate com os métodos para registrar em console, arquivo e memória
            LogDelegate = LogToConsole;
            LogDelegate += LogToFile;
            LogDelegate += LogToMemory;
        }

        public void OnPost()
        {
            if (!ModelState.IsValid)
                return;

            // Configura o multicast delegate
            LogDelegate = LogToConsole;
            LogDelegate += LogToFile;
            LogDelegate += LogToMemory;

            LogDelegate.Invoke(LogMessage);
        }

        private void LogToConsole(string message)
        {
            Console.WriteLine($"LOG (Console): {message}");
        }

        private void LogToFile(string message)
        {
            var logPath = Path.Combine(Directory.GetCurrentDirectory(), "Logs");
            if (!Directory.Exists(logPath))
                Directory.CreateDirectory(logPath);

            var filePath = Path.Combine(logPath, "system.log");
            var logEntry = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - {message}{Environment.NewLine}";

            System.IO.File.AppendAllText(filePath, logEntry);
        }

        private void LogToMemory(string message)
        {
            MemoryLogList.Add($"{DateTime.Now:HH:mm:ss} - {message}");
        }
    }
}
