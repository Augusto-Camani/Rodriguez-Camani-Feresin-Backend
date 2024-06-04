using System.ComponentModel.DataAnnotations;
using Rodriguez_Camani_Feresin_Backend.Models;

namespace Rodriguez_Camani_Feresin_Backend;

public class Client : User
{
    public Client() : base()
    {
        UserType = Enums.UserType.Client;
    }
    public Gender Gender { get; set; }
    public int Age { get; set; }
    public int PhoneNumber { get; set; }
    public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
}
