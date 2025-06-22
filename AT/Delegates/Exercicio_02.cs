using System;
using System.Collections.Generic;

namespace AT
{
    internal class Exercicio_02
    {
        private List<string> memoryLog = new List<string>();

        internal void Start()
        {
            // Cria o multicast delegate com os três métodos
            Action<string> logDelegate = LogToConsole;
            logDelegate += LogToFile;
            logDelegate += LogToMemory;

            // Simula uma operação no sistema
            string nome = "Samuel Hermany";
            logDelegate($"Criação de reserva para {nome}");

            // Exibe o que foi armazenado na memória (apenas para visualização)
            Console.WriteLine("\nConteúdo do log em memória:");
            foreach (string msg in memoryLog)
                Console.WriteLine(msg);

            Console.ReadKey();
        }

        void LogToConsole(string nome) => Console.WriteLine($"Criação de reserva no console para {nome}!");

        void LogToFile(string nome) => Console.WriteLine($"Criação de reserva no arquivo para {nome}!");

        void LogToMemory(string nome) => Console.WriteLine($"Criação de reserva em mamória paa, {nome}!");
    }
}
