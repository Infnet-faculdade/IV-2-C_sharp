using System;
using System.Globalization;

namespace AT
{
    internal class Exercicio_01
    {
        public delegate double CalculateDelegate(double value);
        internal void Start()
        {
            string item = "Diária da Propriedade";
            Console.Write($"Informe o valor original da {item}: ");
            string input = Console.ReadLine();

            if (double.TryParse(input, NumberStyles.Any, CultureInfo.GetCultureInfo("pt-BR"), out double preco))
            {
                // Passa referência do método, sem invocá-lo
                CalculateDelegate parameterDelegate = new CalculateDelegate(CalcularDesconto);

                // Chama o delegate e imprime o resultado
                double precoFinal = parameterDelegate(preco);
                Console.WriteLine($"Valor final da {item} com desconto: {precoFinal:F2}");
            }
            else
            {
                Console.WriteLine("Valor inválido.");
            }


            Console.ReadKey();
        }

        private double CalcularDesconto(double value)
        {
            return value * 0.9;
        }
    }
}
