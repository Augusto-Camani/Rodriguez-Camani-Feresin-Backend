using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rodriguez_Camani_Feresin_Backend;

public class Reply
{
    [ForeignKey("ReviewId")]
    public Review Review { get; set; }
    public int ReviewId { get; set; }
    [Required]
    public string Response { get; set; }
}
