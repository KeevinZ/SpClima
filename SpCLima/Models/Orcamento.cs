using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SpCLima.Models;

[Table("orcamento")]
public class Orcamento
{
    [Key]
    public int Id { get; set; }

    [Required]
    public DateTime DataPedido { get; set; }

    [Required]
    public DateTime DataAgendamento { get; set; }


    [Required]
    public int ClienteId { get; set; }
    public Cliente Cliente { get; set; }

    [Required]
    public int StatusOrcamentoId { get; set; }
    public StatusOrcamento StatusOrcamento { get; set; }

    [StringLength(300, ErrorMessage ="A Descrição Do Pedido deve possuir no máximo 300 caracteres")]
    public string DescricaoPedido { get; set; }

    [StringLength(1000, ErrorMessage ="A Observação deve possuir no máximo 1000 caracteres")]
    public string Observacao { get; set; }

    [Required]
    public DateTime DataOrcamento { get; set; }

    [StringLength(50)]
    public string Desconto { get; set; }

    [Required]
    public decimal Total { get; set; }

    [Required]
    public bool Situacao { get; set; }
}

