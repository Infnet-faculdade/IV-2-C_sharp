using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.ComponentModel.DataAnnotations;

namespace TurismoApp.Pages
{
    public class CalculateTotalModel : PageModel
    {
        [BindProperty]
        [Required(ErrorMessage = "Informe o número de diárias.")]
        [Range(1, 365, ErrorMessage = "Número de diárias inválido.")]
        public int Diarias { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Informe o preço da diária.")]
        [Range(1, 100000, ErrorMessage = "Preço inválido.")]
        public decimal PrecoDiaria { get; set; }

        public decimal? ResultadoTotal { get; set; }

        public void OnPost()
        {
            if (!ModelState.IsValid)
                return;

            // Func com expressão lambda
            Func<int, decimal, decimal> calcularTotal = (dias, preco) => dias * preco;

            ResultadoTotal = calcularTotal(Diarias, PrecoDiaria);
        }
    }
}
