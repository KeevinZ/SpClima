using System.ComponentModel.DataAnnotations;

namespace SpClima.ViewModels;

public class LoginVM
{
    [Required(ErrorMessage = "O usuário é obrigatório.")]
    [Display(Name = "Usuário")]
    public string Username { get; set; }

    [Required(ErrorMessage = "A senha é obrigatória.")]
    [DataType(DataType.Password)]
    [Display(Name = "Senha")]
    public string Password { get; set; }

    public string ReturnUrl { get; set; }
}
