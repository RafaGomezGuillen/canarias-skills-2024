//using backend.Models;
using backend.Models;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

public class User:IdentityUser
{
    public virtual List<Reserva>? Reservas { get; set; }
}

public class UserFields
{
    public string Username { get; set; }

    public string Email { get; set; }
    public List<string> Roles { get; set; }

    public virtual List<Reserva>? Reservas { get; set; }
}

public class UserLogin
{
    [Required(ErrorMessage = "Username is required.")]
    public string Username { get; set; }

    [Required(ErrorMessage = "Password is required.")]
    public string Password { get; set; }
}

public class UserRegister
{
    [EmailAddress]
    [Required(ErrorMessage = "Email is required.")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Username is required.")]
    public string Username { get; set; }

    [Required(ErrorMessage = "Password is required.")]
    public string Password { get; set; }
}
