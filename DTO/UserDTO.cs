﻿using System.ComponentModel.DataAnnotations;

namespace Rodriguez_Camani_Feresin_Backend;

public class UserDTO
{
    public string? UserName { get; set; }
    public string? PasswordHash { get; set; }
}
