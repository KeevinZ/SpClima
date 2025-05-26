using System.ComponentModel.DataAnnotations;

namespace SpClima.ViewModels;

public class LoginVM
{
    [Required]
    public string Username { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    // para enviar a URL de retorno pro modal
    public string ReturnUrl { get; set; }
}
