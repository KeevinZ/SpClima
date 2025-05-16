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

  public bool Destaque { get; set; } = false;

  [Display(Name = "Imagem")]
  public string ImagemUrl { get; set; }

  // Relação com as variações (BTU, tamanho) e preços
  public ICollection<ItemVariacao> Variacoes { get; set; }
      = new List<ItemVariacao>();
}

