using Rodriguez_Camani_Feresin_Backend.Models;

namespace Rodriguez_Camani_Feresin_Backend;

public class Client : User
{
    public Client() : base()
    {
        UserType = Enums.UserType.Client.ToString();
        
    }

}
