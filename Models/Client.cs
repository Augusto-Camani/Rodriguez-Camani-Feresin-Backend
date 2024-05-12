using System.ComponentModel.DataAnnotations;
using Rodriguez_Camani_Feresin_Backend.Models;

namespace Rodriguez_Camani_Feresin_Backend;

public class Client : User
{
    public Client() : base()
    {
        UserType = Enums.UserType.Client.ToString();

    }
    [Required]
    public int ClientDNI { get; set; }
    public Gender Gender { get; set; }
    public Address Address { get; set; }
    public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

}
