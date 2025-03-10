using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace SpCLima.Models;

[Table("confirmacao")]
public class Confirmacao
{
    [Key]
    public int Id { get; set; }

    [Required]
    [DataType(DataType.Date)]
    public DateTime DataConfirmação { get; set; }
}
