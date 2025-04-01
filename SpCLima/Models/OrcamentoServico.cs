using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace SpCLima.Models;

[Table("orcamento_servico")]
public class OrcamentoServico
{
    [Key]
    public int Id { get; set; }


    [ForeignKey("Orcamento")]
    [Column("orcamento_id")]
    public int OrcamentoId { get; set; }
    public Orcamento Orcamento { get; set; }

    [ForeignKey("Servico")]
    [Column("servico_id")]
    public int ServicoId { get; set; }
    public Servico Servico { get; set; }

    [ForeignKey("Btu")]
    [Column("btu_id")]
    public int? BtuId { get; set; } // Nullable para serviços que não usam BTU
    public Btu? Btu { get; set; }
}

