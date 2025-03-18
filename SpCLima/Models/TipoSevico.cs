using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SpCLima.Models;

[Table("tipo_servico")]
public class TipoSevico
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "Por favor, informe o nome da categoria")]
    [StringLength(30, ErrorMessage = "A Categoria  deve possuir no máximo 30 caracteres")]
    public string Categoria { get; set; }

    [StringLength(300)]
    public string Foto { get; set; }
}
