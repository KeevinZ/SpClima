using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SpClima.Models;

namespace SpCLima.Models;

[Table("orcamento")]
public class Orcamento
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime DataCriacao { get; set; }

    [Required(ErrorMessage = "O status é obrigatório")]
    public Enum Status { get; set; }

    [Column("valor_total", TypeName = "decimal(10,2)")]
    public decimal ValorTotal { get; set; }


    [ForeignKey("Usuario")]
    [Column("usuario_id")]
    public int UsuarioId { get; set; }
    public Usuario Usuario { get; set; }

    [ForeignKey("Eletrodomestico")]
    [Column("eletrodomestico_id")]
    public int EletrodomesticoId { get; set; }
    public Eletrodomestico Eletrodomestico { get; set; }

    // Relacionamento com OrcamentoServico
    public ICollection<OrcamentoServico> Servicos { get; set; }
}


