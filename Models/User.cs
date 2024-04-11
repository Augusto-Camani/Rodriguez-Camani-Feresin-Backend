using System;
using System.Collections.Generic;

namespace Rodriguez_Camani_Feresin_Backend.Models;

public partial class User
{
    public int Id { get; set; }

    public string? UserName { get; set; }

    public string? PasswordHash { get; set; }

    public string? Email { get; set; }

    public string? UserType { get; set; }
}
