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
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required(ErrorMessage = "O nome é obrigatório")]
    [StringLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres")]
    [Column("nome")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "Por favor, Informe o CPF")]
    [StringLength(14)]
    [CpfValidation(ErrorMessage = "CPF inválido")]
    public string CPF { get; set; }

    [Required(ErrorMessage = "O telefone é obrigatório")]
    [StringLength(20, ErrorMessage = "Telefone no formato (00) 00000-0000")]
    [Column("telefone")]
    public string Telefone { get; set; }

    [Required(ErrorMessage = "O endereço é obrigatório")]
    [Column("endereco")]
    public string Endereco { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    [Column("data_cadastro")]
    public DateTime DataCadastro { get; set; }

    // Relacionamento com Eletrodomestico e Orcamento
    public ICollection<Eletrodomestico> Eletrodomesticos { get; set; }
    public ICollection<Orcamento> Orcamentos { get; set; }
}
