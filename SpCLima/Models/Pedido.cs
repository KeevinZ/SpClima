using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace SpClima.Models;

[Table("pedido")]
public class Pedido

{
    [Key]
    public int Id { get; set; }

    public int ItemId { get; set; }
    public Item Item { get; set; }

    public int ItemVariacaoId { get; set; }
    public ItemVariacao ItemVariacao { get; set; }

    [Column(TypeName = "decimal(10,2)")]
    public decimal Preco { get; set; }  // Preço congelado no momento

    public string? DescricaoPersonalizada { get; set; }

    public string ClienteNome { get; set; }
    public string ClienteEndereco { get; set; }
    public string ClienteTelefone { get; set; }

    public bool Validado { get; set; }  
}
