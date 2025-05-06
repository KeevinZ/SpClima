using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SpClima.Models;


namespace SpCLima.Models;

[Table("produto")]
public class Produto
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "Por favor, informe a Categoria")]
    public int CategoriaId { get; set; }

    [ForeignKey(nameof(CategoriaId))]
    public Categoria Categoria { get; set; }

    [Required(ErrorMessage = "Por favor, informe o Nome")]
    [StringLength(60, ErrorMessage = "O Nome deve possuir o máximo 60 caracteres")]
    public string Nome { get; set; }

    public int? BTU { get; set; }

    public List<ProdutoFoto> Fotos { get; set; }
}
    