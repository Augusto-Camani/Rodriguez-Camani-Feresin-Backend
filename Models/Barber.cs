using Rodriguez_Camani_Feresin_Backend.Models;

namespace Rodriguez_Camani_Feresin_Backend;

public class Barber : User
{
    public Barber() : base()
    {
        UserType = Enums.UserType.Barber.ToString();
    }

}
