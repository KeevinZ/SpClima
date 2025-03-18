
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace SpCLima.Models;

[Table("servico")]
public class Servico
{
    [Required]
    public int Id { get; set; }

    [Required(ErrorMessage = "Por favor, informe o Qual Tipo Do Serviço")]
    public int TipoServicoId { get; set; }
    [ForeignKey(nameof(TipoServicoId))]
    public TipoSevico TipoServico { get; set; }

    [Required(ErrorMessage = "Por favor, informe o Nome Do Serviço")]
    [StringLength(100, ErrorMessage = "O Nome deve possuir no máximo 100 caracteres")]
    public string NomeDoServico { get; set; }

    [Display(Name = "Descrição", Prompt = "Descrição")]
    [StringLength(1000, ErrorMessage = "A Descrição deve possuir no máximo 1000 caracteres")]
    public string Descricao { get; set; }

    [Range(0, double.MaxValue)]
    [Column(TypeName = "numeric(10,2)")]
    public decimal Valor { get; set; }

    public List<ServicoFoto> Fotos { get; set; }
}
