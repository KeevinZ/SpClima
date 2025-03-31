using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace SpCLima.Models;

[Table("btu")]
public class Btu
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required(ErrorMessage = "O valor do BTU é obrigatório")]
    [Column("valor_btu")]
    public int ValorBtu { get; set; }

    [Required(ErrorMessage = "O ajuste de preço é obrigatório")]
    [Column("preco_ajuste", TypeName = "decimal(10,2)")]
    public decimal PrecoAjuste { get; set; }

    // Relacionamento com OrcamentoServico
    public ICollection<OrcamentoServico> OrcamentoServicos { get; set; }
}