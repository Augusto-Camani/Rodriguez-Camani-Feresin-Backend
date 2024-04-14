using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Rodriguez_Camani_Feresin_Backend.Models
{
    public class Review
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? ClientComment { get; set; }
        public string ClientUsername { get; set; }
        public decimal ClientRating { get; set; }

        [ForeignKey("ClientId")]
        public Client Client { get; set; }
        public int? ClientId { get; set; }
        [ForeignKey("AppointmentId")]
        //public Gam Game { get; set; }
        public int AppointmentId { get; set; }
        public DateTime CreationDate { get; set; }
        //public ICollection<Game> Games { get; set; }
    }
}
