using System;

namespace AT
{
    internal class GerenciamentoReservas
    {
        public event Action CapacityReached;

        private int limite;
        private int totalReservas;

        public GerenciamentoReservas(int limite)
        {
            this.limite = limite;
            totalReservas = 0;
        }

        public void AdicionarReserva()
        {
            totalReservas++;

            if (totalReservas > limite)
            {
                CapacityReached?.Invoke();
            }
        }
    }
}
