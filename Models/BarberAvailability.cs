using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rodriguez_Camani_Feresin_Backend;

public class BarberAvailability
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int BarberAvailabilityId { get; set; }
    [ForeignKey("BarberScheduleId")]
    public BarberSchedule BarberSchedule { get; set; }
    public int BarberScheduleId { get; set; }
    public DaysOfTheWeek DayOfTheWeek { get; set; }
    public DateTime AvailabilityDate { get; set; }
    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }
    public bool IsAvailable { get; set; }
}
