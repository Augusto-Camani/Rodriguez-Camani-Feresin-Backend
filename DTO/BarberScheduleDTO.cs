namespace Rodriguez_Camani_Feresin_Backend;

public class BarberScheduleDTO
{
    public int BarberScheduleId { get; set; }
    public int BarberId { get; set; }
    public int CurrentYear { get; set; }
    public DateTime LastModifiedDate { get; set; }
    public List<BarberAvailabilityDTO> AvailabilitySlots { get; set; } = new List<BarberAvailabilityDTO>();
}
