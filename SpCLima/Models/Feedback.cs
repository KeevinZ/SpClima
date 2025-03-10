
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SpClima.Models;

namespace SpCLima.Models;

[Table("feedback")]
public class Avaliacao
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    public int ClienteId { get; set; }
    public Usuario Usuario { get; set; }

    [Required]
    public int ServicosId { get; set; }
    public TipoServico TipoServico { get; set; }

    [Required, Range(1, 5, ErrorMessage = "A nota deve ser entre 1 e 5")]
    public int Nota { get; set; }

    [StringLength(500)]
    public string Comentario { get; set; }

    [Required]
    public DateTime DataAvaliacao { get; set; }
}
