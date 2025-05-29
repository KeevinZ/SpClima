using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpClima.Models;

[Table("Item_categoria")]
public class ItemCategoria
{
    [Key]
    public int Id { get; set; }

    [Required, StringLength(50)]
    public string Nome { get; set; }
}