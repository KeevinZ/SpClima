using System.ComponentModel.DataAnnotations;

namespace SpClima.ViewModels;

public class LoginVM
{
    [Required]
    public string Username { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    public string ReturnUrl { get; set; }
}
