using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rodriguez_Camani_Feresin_Backend;

public class BarberSchedule
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int BarberScheduleId { get; set; }
    [ForeignKey("BarberId")]    
    public Barber Barber { get; set; }
    public int BarberId { get; set; }
    public int CurrentYear { get; set; } = System.DateTime.UtcNow.Year;
    public DateTime LastModifiedDate { get; set; } = System.DateTime.UtcNow;
    public ICollection<BarberAvailability> AvailabilitySlots {get ; set; } = new List<BarberAvailability>();    
}
