using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace SpClima.Models;

[Table("item_variacao")]
public class ItemVariacao
{
    [Key]
    public int Id { get; set; }

    [Required]
    public int ItemId { get; set; }
    public Item Item { get; set; }

    [Required, StringLength(60)]
    public string Nome { get; set; }   // “9000 BTUs”, “12000 BTUs”, “Pequena”, “Grande”, etc.

    [Column(TypeName = "decimal(10,2)")]
    [Range(0, double.MaxValue)]
    public decimal Preco { get; set; }

    public ICollection<OrcamentoItem> OrcamentoItems { get; set; }
}

