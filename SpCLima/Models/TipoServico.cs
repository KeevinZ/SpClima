using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Intrinsics.X86;


namespace SpCLima.Models;

[Table("tipo_servico")]
public class TipoServico
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "Por favor, informe o nome")]
    [StringLength(30, ErrorMessage = "O nome  deve possuir no máximo 30 caracteres")]
    public string Nome { get; set; }

    [StringLength(300)]
    public string Foto { get; set; }

    public ICollection<Servico> Servicos { get; set; }
}
