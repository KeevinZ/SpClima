using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SpClima.Models;

namespace SpCLima.Models;

[Table("eletrodomestico")]
public class Eletrodomestico
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required(ErrorMessage = "O tipo é obrigatório")]
    public string Tipo { get; set; }

    [StringLength(50, ErrorMessage = "A marca deve ter no máximo 50 caracteres")]
    public string Marca { get; set; }

    [StringLength(50, ErrorMessage = "O modelo deve ter no máximo 50 caracteres")]
    public string Modelo { get; set; }


    [ForeignKey("Usuario")]
    [Column("usuario_id")]
    public int UsuarioId { get; set; }
    public Usuario Usuario { get; set; }

    // Relacionamento com Orcamento
    public ICollection<Orcamento> Orcamentos { get; set; }
}