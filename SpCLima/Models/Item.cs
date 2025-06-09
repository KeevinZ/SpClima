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

  public int ItemCategoriaId { get; set; }

  [ForeignKey("ItemCategoriaId")]
  public ItemCategoria Categoria { get; set; }

  public bool Destaque { get; set; } = false;

  [Display(Name = "Imagem")]
  public string ImagemUrl { get; set; }

  public List<ItemVariacao> Variacoes { get; set; }
}

