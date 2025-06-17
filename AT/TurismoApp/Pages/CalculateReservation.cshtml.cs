using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.ComponentModel.DataAnnotations;

namespace TurismoApp.Pages
{
    public class CalculateReservationModel : PageModel
    {
        [BindProperty]
        [Range(1, int.MaxValue, ErrorMessage = "Informe um n�mero v�lido de di�rias (m�nimo 1).")]
        public int NumberOfDays { get; set; }

        [BindProperty]
        [Range(0.01, double.MaxValue, ErrorMessage = "Informe um valor v�lido para a di�ria.")]
        public decimal DailyRate { get; set; }

        public decimal? TotalValue { get; set; }

        // Func para calcular o total
        private readonly Func<int, decimal, decimal> calculateTotal = (days, rate) => days * rate;

        public void OnGet()
        {
            // Inicializa��es se precisar
        }

        public void OnPost()
        {
            if (!ModelState.IsValid)
            {
                TotalValue = null;
                return;
            }

            TotalValue = calculateTotal(NumberOfDays, DailyRate);
        }
    }
}
