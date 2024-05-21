namespace Rodriguez_Camani_Feresin_Backend;

public class BarberDTO
{
    public string UserName { get; set; }

    public string PasswordHash { get; set; }

    public string Email { get; set; }

    public Specialties Specialties { get; set; }
}
