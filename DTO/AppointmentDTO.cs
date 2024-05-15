namespace Rodriguez_Camani_Feresin_Backend.DTO
{
    public class AppointmentDTO
    {
        public int Id { get; set; }
        public string ClientName { get; set; }
        public string Barber { get; set; }
        public string Product { get; set; }
        public bool Prepaid { get; set; }
        public DateTime CreationDate { get; set; }
    }
}