using System.ComponentModel.DataAnnotations.Schema;

namespace SpClima.Models;

[Table("orcamento_item")]
public class OrcamentoItem
{
    public int OrcamentoId { get; set; }
    public Orcamento Orcamento { get; set; }

    public int ItemVariacaoId { get; set; }
    public ItemVariacao Variacao { get; set; }

    public int ItemId { get; set; }
    public Item Item { get; set; }

    // Preço padrão no momento do orçamento
    [Column(TypeName = "decimal(10,2)")]
    public decimal PrecoEstimado { get; set; }

    [Column(TypeName = "decimal(10,2)")]
    public decimal? PrecoFinal { get; set; }

    // Texto explicando como o serviço deve ser feito
    public string? DescricaoPersonalizada { get; set; }
}
