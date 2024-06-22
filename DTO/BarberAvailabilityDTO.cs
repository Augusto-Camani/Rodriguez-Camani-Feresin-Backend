namespace Rodriguez_Camani_Feresin_Backend;

public class BarberAvailabilityDTO
{
    public int BarberAvailabilityId { get; set; }
    public int BarberScheduleId { get; set; }
    public DaysOfTheWeek DayOfTheWeek { get; set; }
    public DateTime AvailabilityDate { get; set; }
    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }
    public bool IsAvailable { get; set; }
}
