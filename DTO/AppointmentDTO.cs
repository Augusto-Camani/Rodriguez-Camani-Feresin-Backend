namespace Rodriguez_Camani_Feresin_Backend.DTO
{
    public class AppointmentDTO
    {
        public int ClientId { get; set; }
        public int BarberId { get; set; }
        public string Service { get; set; }
        public TimeSpan StartTime { get; set; }
        public DateTime CreationDate { get; set; }
    }
}