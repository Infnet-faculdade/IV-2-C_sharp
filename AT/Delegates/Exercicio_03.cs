using System;

namespace AT
{
    internal class Exercicio_03
    {
        internal void Start()
        {
            Console.WriteLine("Informe os dados para cálculo do valor total da reserva:");

            Console.Write("Insira o valor da diária: ");
            string inputDiaria = Console.ReadLine();

            Console.Write("Insira a qauntidade de diárias: ");
            string inputDias = Console.ReadLine();

            if (int.TryParse(inputDiaria, out int valorDiaria) && int.TryParse(inputDias, out int numeroDias))
            {
                Func<int, int, decimal> calcularTotal = (valor, dias) => valor * dias;

                decimal total = calcularTotal(valorDiaria, numeroDias);
                Console.WriteLine($"Valor total da reserva: R$ {total:F2}");
            }
            else
            {
                Console.WriteLine("Valores inválidos.");
            }
        }
    }
}
