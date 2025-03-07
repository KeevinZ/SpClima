using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpClima.Models;

[Table("tipo_de_servico")]
public class TipoDeServico
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "Por favor, informe uma categoria")]
    public int CategoriaId { get; set; }

    [ForeignKey(nameof(CategoriaId))]
    public Categoria Categoria { get; set; }

    [Required(ErrorMessage = "Por favor, informe um nome para o serviço")]
    [StringLength(60, ErrorMessage = "O nome deve possuir no máximo 60 caracteres")]
    public string Nome { get; set; }

    [Display(Name = "Descrição")]
    [StringLength(1000, ErrorMessage = "A descrição deve possuir no máximo 1000 caracteres")]
    public string Descricao { get; set; }

    [Range(0, double.MaxValue)]
    [Column(TypeName = "numeric(10,2)")]
    public decimal ValorBase { get; set; }

    public bool Destaque { get; set; } = false;

    [Required]
    [StringLength(300)]
    [Display(Name = "Foto do serviço")]
    public string Foto { get; set; }
    public int TipoDeServicoId { get; internal set; }
}
