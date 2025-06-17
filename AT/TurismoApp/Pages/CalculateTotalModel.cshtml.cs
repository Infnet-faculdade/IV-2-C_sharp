using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using TurismoApp.Models;

namespace TurismoApp.Pages
{
    public class CapacityTestModel : PageModel
    {
        public string Mensagem { get; set; }
        public int QuantidadeReservas { get; set; }
        public int Capacidade { get; set; }

        // Armazenar o pacote como campo da página para manter estado temporário
        private static PacoteTuristico pacote;

        public void OnGet()
        {
            InicializarPacote(); // Inicializa para exibir os dados corretamente
        }

        public void OnPost()
        {
            InicializarPacote();

            // Assinar o evento só uma vez
            if (pacote.CapacityReached == null || pacote.CapacityReached.GetInvocationList().Length == 0)
            {
                pacote.CapacityReached += (sender, args) =>
                {
                    Mensagem = "?? Capacidade máxima atingida para o pacote!";
                    Console.WriteLine(Mensagem);
                };
            }

            pacote.AdicionarReserva(new Reserva
            {
                Id = pacote.Reservas.Count + 1,
                ClienteId = 200 + pacote.Reservas.Count,
                PacoteTuristicoId = pacote.Id,
                DataReserva = DateTime.Now
            });

            QuantidadeReservas = pacote.Reservas.Count;
            Capacidade = pacote.CapacidadeMaxima;
        }

        private void InicializarPacote()
        {
            if (pacote == null)
            {
                pacote = new PacoteTuristico
                {
                    Id = 1,
                    Titulo = "Pacote Teste",
                    DataInicio = DateTime.Today.AddDays(5),
                    CapacidadeMaxima = 3,
                    Preco = 1500m
                };
            }

            QuantidadeReservas = pacote.Reservas.Count;
            Capacidade = pacote.CapacidadeMaxima;
        }
    }
}
