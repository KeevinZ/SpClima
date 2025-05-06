using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SpClima.Models;

namespace SpCLima.Models;

[Table("servico")]
public class Servico
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "O nome do serviço é obrigatório!")]
    [StringLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres.")]
    public string Nome { get; set; }

    [Range(0, (double)decimal.MaxValue)]
    [Column(TypeName = "numeric(10,2)")]
    public decimal Preco { get; set; }


    [Required(ErrorMessage = "Por favor, informe a Categoria")]
    public int CategoriaId { get; set; }

    [ForeignKey(nameof(CategoriaId))]
    public Categoria Categoria { get; set; }
}
