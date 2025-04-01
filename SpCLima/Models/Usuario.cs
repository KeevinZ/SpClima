using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Identity;
using Mysqlx;
using SpCLima.Models;

namespace SpClima.Models;

[Table("usuario")]
public class Usuario : IdentityUser
{

    [Required(ErrorMessage = "O nome é obrigatório")]
    [StringLength(60, ErrorMessage = "O nome deve ter no máximo 60 caracteres")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "Por favor, Informe o CPF")]
    [CpfValidation(ErrorMessage = "CPF inválido")]
    public string CPF { get; set; }

    [Required(ErrorMessage = "O telefone é obrigatório")]
    [StringLength(20, ErrorMessage = "Telefone no formato (00) 00000-0000")]
    public string Telefone { get; set; }

    [Required(ErrorMessage = "O endereço é obrigatório")]
    public string Endereco { get; set; }
    
    [Display(Name = "Data de Nascimento")]
    [DataType(DataType.Date)]
    public DateTime DataNascimento { get; set; }

    // Relacionamento com Eletrodomestico e Orcamento
    public ICollection<Eletrodomestico> Eletrodomesticos { get; set; }
    public ICollection<Orcamento> Orcamentos { get; set; }
}
