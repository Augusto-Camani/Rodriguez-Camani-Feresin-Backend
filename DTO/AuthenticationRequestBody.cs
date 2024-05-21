using System.ComponentModel.DataAnnotations;

namespace Rodriguez_Camani_Feresin_Backend;

public class AuthenticationRequestBody
{
    [Required]
    public string UserName { get; set; }
    [Required]
    public string Password { get; set; }
}
