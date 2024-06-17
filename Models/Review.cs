using Rodriguez_Camani_Feresin_Backend.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rodriguez_Camani_Feresin_Backend;

public class Review
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ReviewId { get; set; }
    [Required]
    public string UserName { get; set; }
    public decimal Rating { get; set; }
    public string? Description { get; set; }
    public Reply Reply { get; set; }

    [ForeignKey("AppointmentId")]
    public Appointment Appointment { get; set; }
    public int AppointmentId { get; set; }

    [ForeignKey("UserId")]
    public User User { get; set; }
    public int UserId { get; set; }

    public DateTime CreationDate { get; set; }

}
