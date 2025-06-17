using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using TurismoApp.Models;

namespace TurismoApp.Pages
{
    public class CapacityTestModel : PageModel
    {
        public string? Mensagem { get; set; }

        public int QuantidadeReservas { get; set; }
        public int Capacidade { get; set; }

        private static PacoteTuristico pacote;

        static CapacityTestModel()
        {
            // Pacote fixo com capacidade para teste
            pacote = new PacoteTuristico
            {
                Titulo = "Pacote Teste para o Caribe",
                CapacidadeMaxima = 3
            };

            // Evento de capacidade
            pacote.CapacityReached += (mensagem) =>
            {
                UltimaMensagem = mensagem;
            };
        }

        private static string? UltimaMensagem;

        public void OnGet()
        {
            AtualizarEstado();
        }

        public void OnPost()
        {
            pacote.AdicionarReserva(new Reserva { DataReserva = DateTime.Now });
            AtualizarEstado();
        }

        private void AtualizarEstado()
        {
            QuantidadeReservas = pacote.Reservas.Count;
            Capacidade = pacote.CapacidadeMaxima;
            Mensagem = UltimaMensagem;
        }
    }
}
