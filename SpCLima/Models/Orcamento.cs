using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using SpClima.Models;

namespace SpCLima.Models;

[Table("orcamento")]
public class Orcamento
{
    [Key]
    public int Id { get; set; }

    [Required]
    public DateTime DataPedido { get; set; }

    [StringLength(300, ErrorMessage ="A Descrição Do Pedido deve possuir no máximo 300 caracteres")]
    public string DescricaoPedido { get; set; }

    [Required]
    public string StatusOrcamento { get; set; }

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
    public Usuario Usuario { get; set; }

   public ICollection<OrcamentoServico> OrcamentoServicos { get; set; }
}

