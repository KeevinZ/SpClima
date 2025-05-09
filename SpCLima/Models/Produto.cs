using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpClima.Models;

[Table("produto")]
public class Produto
{
    [Key]
    public int Id { get; set; }


    [Required(ErrorMessage = "Por favor, informe o Nome")]
    [StringLength(60, ErrorMessage = "O Nome deve possuir o máximo 60 caracteres")]
    public string Nome { get; set; }

    public int? BTU { get; set; }


    [Required(ErrorMessage = "Por favor, informe a Categoria")]
    public int CategoriaId { get; set; }

    [ForeignKey(nameof(CategoriaId))]
    public Categoria Categoria { get; set; }


    [Required(ErrorMessage = "Por favor, informe a Serviço")]
    public int ServicoId { get; set; }

    [ForeignKey(nameof(ServicoId))]
    public Servico Servico { get; set; }

    public List<Servico> Servicos { get; set; } = new List<Servico>();
    public List<ProdutoFoto> Fotos { get; set; }

}
    