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

    [Required(ErrorMessage = "O nome do cliente é obrigatório.")]
    [StringLength(100, ErrorMessage = "O nome do cliente não pode exceder 100 caracteres.")]
    public string ClienteNome { get; set; }

    [Required(ErrorMessage = "O endereço do cliente é obrigatório.")]
    public string ClienteEndereco { get; set; }

    [Required(ErrorMessage = "O telefone do cliente é obrigatório.")]
    [Phone(ErrorMessage = "Por favor, insira um número de telefone válido.")]
    [StringLength(15, MinimumLength = 10, ErrorMessage = "O telefone deve ter entre 10 e 15 dígitos.")]
    public string ClienteTelefone { get; set; }

    public bool Validado { get; set; }  
}