using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rodriguez_Camani_Feresin_Backend.Models;

public partial class User
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int UserId { get; set; }

    public string? UserName { get; set; }

    public string? PasswordHash { get; set; }

    public string? Email { get; set; }

    public string? UserType { get; set; }
}
