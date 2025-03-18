using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpCLima.Models;

[Table("servico_foto")]
public class ServicoFoto
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "Por favor, informe o Produto")]
    public int ServicoId { get; set; }
    [ForeignKey(nameof(ServicoId))]
    public Servico Servico { get; set; }

    [Required]
    [StringLength(300)]
    [Display(Name = "Arquivo da Foto")]
    public string ArquivoFoto { get; set; }

    [Display(Name = "Descrição")]
    [StringLength(30, ErrorMessage = "A Descrição deve possuir no máximo 30 caracteres")]
    public string Descricao { get; set; }
}