using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpClima.Models;

[Table("produto_foto")]
public class ProdutoFoto
{
    [Key]
    public int Id { get; set; }

    [Required (ErrorMessage = "Informe o nome do Produto")]
    public int ProdutoId { get; set; }

    [ForeignKey(nameof(ProdutoId))]
    public Produto Produto { get; set; }

    [Required]
    [StringLength(300)]
    [Display(Name ="Arquivo da foto")]
    public string ArquivoFoto { get; set; }

    [Display(Name = "Descrição")]
    [StringLength(50, ErrorMessage = "A descrição deve possuir no máximo 50 caracteres")]
    public string Descricao { get; set; }
}
