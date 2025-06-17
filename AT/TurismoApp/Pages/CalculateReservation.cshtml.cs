using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.ComponentModel.DataAnnotations;

namespace TurismoApp.Pages
{
    public class CalculateReservationModel : PageModel
    {
        [BindProperty]
        [Range(1, int.MaxValue, ErrorMessage = "Informe um número válido de diárias (mínimo 1).")]
        public int NumberOfDays { get; set; }

        [BindProperty]
        [Range(0.01, double.MaxValue, ErrorMessage = "Informe um valor válido para a diária.")]
        public decimal DailyRate { get; set; }

        public decimal? TotalValue { get; set; }

        // Func para calcular o total
        private readonly Func<int, decimal, decimal> calculateTotal = (days, rate) => days * rate;

        public void OnGet()
        {
            // Inicializações se precisar
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
