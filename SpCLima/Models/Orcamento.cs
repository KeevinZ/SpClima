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

    [StringLength(300, ErrorMessage ="A Descrição Do Pedido deve possuir no máximo 300 caracteres")]
    public string? DescricaoPedido { get; set; }

    [StringLength(1000, ErrorMessage ="A Observação deve possuir no máximo 1000 caracteres")]
    public string Observacao { get; set; }

    [StringLength(50)]
    public decimal Desconto { get; set; }

    [Required]
    public decimal Total { get; set; }



    [Required]
    [Key, Column(Order = 1)]
    public int ServicoId { get; set; }
    public Servico Servico { get; set; }

    [Required]
    [ForeignKey("cliente")]
    public int ClienteId { get; set; }
    public Cliente Cliente { get; set; }

    [Required]
    [ForeignKey("status_orcamento")]
    public int StatusOrcamentoId { get; set; }
    public StatusOrcamento StatusOrcamento { get; set; }

   public ICollection<OrcamentoServico> OrcamentoServicos { get; set; }
}

