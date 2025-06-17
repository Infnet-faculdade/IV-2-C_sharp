using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.ComponentModel.DataAnnotations;

namespace TurismoApp.Pages
{
    public class CalculateTotalModel : PageModel
    {
        [BindProperty]
        [Required(ErrorMessage = "Informe o n�mero de di�rias.")]
        [Range(1, 365, ErrorMessage = "N�mero de di�rias inv�lido.")]
        public int Diarias { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Informe o pre�o da di�ria.")]
        [Range(1, 100000, ErrorMessage = "Pre�o inv�lido.")]
        public decimal PrecoDiaria { get; set; }

        public decimal? ResultadoTotal { get; set; }

        public void OnPost()
        {
            if (!ModelState.IsValid)
                return;

            // Func com express�o lambda
            Func<int, decimal, decimal> calcularTotal = (dias, preco) => dias * preco;

            ResultadoTotal = calcularTotal(Diarias, PrecoDiaria);
        }
    }
}
