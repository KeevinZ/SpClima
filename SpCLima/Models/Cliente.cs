using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace SpCLima.Models;


[Table("cliente")]
public class Cliente : IdentityUser
{
    [Required(ErrorMessage = "Por favor, informe o nome")]
    [StringLength(60, ErrorMessage = "O nome deve possuir no máximo 60 caracteres")]
    public string Nome { get; set; }

    [Required(ErrorMessage ="Por favor, Informe o Endereço")]
    [StringLength(200, ErrorMessage = "O Endereço deve possuir no máximo 200 caracteres")]
    public string Endereco { get; set; }

    [EmailAddress(ErrorMessage ="Por favor, Informe o Email")]
    public string Email { get; set; }

    [Phone(ErrorMessage="Por favor, Informe o Número De Telefone")]
    public string Telefone { get; set; }

    [Required(ErrorMessage="Por favor, Informe o CPF")]
    [StringLength(14)]
    public string CPF { get; set; }

    [DataType(DataType.Date)]
    [Display(Name = "Dia de nascimento")]
    public DateTime DataNascimento { get; set; }

    [StringLength(300)]
    public string Foto { get; set; }

}
