using System;

namespace AT
{
    internal class Exercicio_04
    {
        internal void Start()
        {
            AT.GerenciamentoReservas manager = new GerenciamentoReservas(3);

            // Delegate registrando o alerta no console
            manager.CapacityReached += () =>
            {
                Console.WriteLine("Limite de capacidade atingido!");
            };

            // Simulação de reservas
            manager.AdicionarReserva(); // 1
            manager.AdicionarReserva(); // 2
            manager.AdicionarReserva(); // 3
            manager.AdicionarReserva(); // 4 -> dispara evento
            manager.AdicionarReserva(); // 5 -> dispara novamente

            Console.ReadKey();
        }
    }
}