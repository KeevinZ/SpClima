using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpClima.Models;

[Table("orcamento")]
public class Orcamento
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string NomeCliente { get; set; }

    // [DataType(DataType.Date)]
    // [Display(Name = "Data do orcamento")]
    // public DateTime DataCriacao { get; set; }

    [Column(TypeName = "numeric(10,2)")]
    public decimal ValorTotal { get; set; }

    public StatusOrcamento Status { get; set; }
    

    public List<Produto> Produtos { get; set; }
    public List<Servico> Servicos { get; set; }
}


