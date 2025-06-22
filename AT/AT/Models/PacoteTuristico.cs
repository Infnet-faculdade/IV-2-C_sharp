namespace AT.Models
{
    public class PacoteTuristico
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public DateTime DataInicio { get; set; }
        public int CapacidadeMaxima { get; set; }
        public decimal Preco { get; set; }

        // Lista de destinos associados ao pacote turístico
        public List<Destino> Destinos { get; set; }
    }
}
