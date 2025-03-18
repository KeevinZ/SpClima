using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpCLima.Models;

[Table("status_orcamento")]
public class StatusOrcamento
{
    public int Id { get; set; }

    [Required]
    [Display(Name = "Descrição")]
    [StringLength(250, ErrorMessage = "A Descrição deve possuir no máximo 250 caracteres")]
    public string Descricao { get; set; }

    [Required]
    public bool Situacao { get; set; }

    [Required]
    public int OrcamentoId { get; set; }
    public Orcamento Orcamento { get; set; }
}