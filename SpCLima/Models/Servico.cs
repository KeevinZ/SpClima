
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SpClima.Models;


namespace SpCLima.Models;

[Table("servico")]
public class Servico
{
    [Required]
    [Key]
    public int Id { get; set; }

    [Required]
    [ForeignKey(nameof(TipoServicoId))]
    public int TipoServicoId { get; set; }
    public TipoServico TipoServico { get; set; }

    [ForeignKey(nameof(ClienteId))]
    public int ClienteId { get; set; }
     public Usuario Usuario { get; set; }


    [Required(ErrorMessage = "Por favor, informe o Nome Do Serviço")]
    [StringLength(100, ErrorMessage = "O Nome deve possuir no máximo 100 caracteres")]
    public string NomeDoServico { get; set; }

    [Display(Name = "Descrição", Prompt = "Descrição")]
    [StringLength(1000, ErrorMessage = "A Descrição deve possuir no máximo 1000 caracteres")]
    public string Descricao { get; set; }

    [Range(0, double.MaxValue)]
    [Column(TypeName = "numeric(10,2)")]
    public decimal Valor { get; set; }

    public ICollection<OrcamentoServico> OrcamentoServicos { get; set; }
    public int BtuId { get; internal set; }
}
