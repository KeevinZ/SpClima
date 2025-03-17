using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpCLima.Models;

[Table("orcamento_servico")]
public class OrcamentoServico
{
    [Key, Column(Order = 0)]
    [Required]
    public int OrcamentoId { get; set; }
    public Orcamento Orcamento { get; set; }

    [Key, Column(Order = 1)]
    [Required]
    public int ServicoId { get; set; }
    public Servico Servico { get; set; }

    [Required]
    public decimal Valor { get; set; }
}

