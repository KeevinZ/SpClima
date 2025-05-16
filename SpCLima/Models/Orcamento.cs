using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpClima.Models;

[Table("orcamento")]
public class Orcamento
{
    public int Id { get; set; }
    public string UsuarioId { get; set; }
    public DateTime DataCriacao { get; set; } = DateTime.Now;
    public decimal ValorTotal { get; set; }
    public ICollection<OrcamentoItem> OrcamentoItens { get; set; } = new List<OrcamentoItem>();
}