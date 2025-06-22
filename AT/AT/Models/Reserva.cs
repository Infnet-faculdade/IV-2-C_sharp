namespace AT.Models
{
    public class Reserva
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public Cliente? Cliente { get; set; }

        // Foreign key PacoteTuristico
        public int PacoteTuristicoId { get; set; }
        public PacoteTuristico? PacoteTuristico { get; set; }
        public DateTime DataReserva { get; set; }
    }
}
