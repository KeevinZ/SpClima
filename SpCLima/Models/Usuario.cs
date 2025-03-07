using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace SpClima.Models;

[Table("usuario")]
public class Usuario : IdentityUser
{
    [Required(ErrorMessage = "Por favor, informe o nome")]
    [StringLength(60, ErrorMessage = "O nome deve possuir no máximo 60 caracteres")]
    public string Nome { get; set; }

    [DataType(DataType.Date)]
    [Display(Name = "Dia de nascimento")]
    public DateTime DataNascimento { get; set; }

    [StringLength(300)]
    public string Foto { get; set; }
}
