using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpClima.Models;

[Table("item")]
public class Item
{
  [Key]
  public int Id { get; set; }

  [Required, StringLength(120)]
  public string Titulo { get; set; }            // “Instalação de Ar‑Condicionado”

  [StringLength(500)]
  public string Descricao { get; set; }         // “Instalação padrão…”

  [Display(Name = "Tipo")]
  public ItemType Tipo { get; set; }            // ArCondicionado ou CortinaAr


  [Column(TypeName = "decimal(10,2)")]
  [Range(0, double.MaxValue)]
  public decimal Preco { get; set; }

  public bool Destaque { get; set; } = false;

  [Display(Name = "Imagem")]
  public string ImagemUrl { get; set; }


  public ICollection<ItemVariacao> Variacoes { get; set; }
  public ICollection<OrcamentoItem> OrcamentoItems { get; set; }
}

