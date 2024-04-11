using Rodriguez_Camani_Feresin_Backend.Enums;
using Rodriguez_Camani_Feresin_Backend.Models;

namespace Rodriguez_Camani_Feresin_Backend;

public class Admin : User
{
public Admin(): base()
{
    UserType = Enums.UserType.Admin.ToString();
}
}
