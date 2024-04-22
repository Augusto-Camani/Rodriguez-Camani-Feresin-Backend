using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Rodriguez_Camani_Feresin_Backend.Models
{
    public class Appointments
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Appointment_id { get; set; }
        public string ClientName { get; set; }
        public decimal Product { get; set; }
        public DateTime FechayHora { get; set; }

        [ForeignKey("ClientId")]
        public Client Client { get; set; }
        public int? ClientId { get; set; }
        
        [ForeignKey("BarberId")]
        public Barber Barber { get; set; }
        public int? BarberId { get; set; }
        public string PaymentMethod { get; set; }
        
    }
}
