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
    public int ReceiptNumber { get; set; }
    public string? Description { get; set; }

    [ForeignKey("ClientId")]
    public Client Client { get; set; }
    public int ClientId { get; set; }

    [ForeignKey("BarberId")]

    public Barber Barber { get; set; }
    public int BarberId { get; set; }
}
