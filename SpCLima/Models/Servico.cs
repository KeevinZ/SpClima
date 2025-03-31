
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SpClima.Models;


namespace SpCLima.Models;

[Table("servico")]
public class Servico
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required(ErrorMessage = "O nome do serviço é obrigatório")]
    [StringLength(50, ErrorMessage = "O nome deve ter no máximo 50 caracteres")]
    [Column("nome")]
    public string Nome { get; set; }

    [StringLength(1000, ErrorMessage = "A descrição deve ter no máximo 1000 caracteres")]
    [Column("descricao")]
    public string? Descricao { get; set; }

    [Required(ErrorMessage = "O preço base é obrigatório")]
    [Range(0, double.MaxValue, ErrorMessage = "O preço deve ser positivo")]
    [Column("preco_base", TypeName = "decimal(10,2)")]
    public decimal PrecoBase { get; set; }

    // Relacionamento com OrcamentoServico
    public ICollection<OrcamentoServico> OrcamentoServicos { get; set; }
}
