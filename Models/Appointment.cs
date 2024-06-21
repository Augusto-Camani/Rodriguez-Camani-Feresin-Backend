using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rodriguez_Camani_Feresin_Backend;

public class Appointment
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int AppointmentId { get; set; }
    [Required]
    public DateTime DateTime { get; set; }
    public TimeSpan StartTime { get; set; }
    public Service Service { get; set; }
    public Status Status { get; set; }

    [ForeignKey("ClientId")]
    public Client Client { get; set; }
    public int ClientId { get; set; }

    [ForeignKey("BarberId")]

    public Barber Barber { get; set; }
    public int BarberId { get; set; }

    [ForeignKey("BarberAvailabilityId")]
    public BarberAvailability BarberAvailability { get; set; }
    public int BarberAvailabilityId { get; set; }
    public Review Review { get; set;}
}
