using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SpClima.Models;

namespace SpCLima.Models;

[Table("orcamento")]
public class Orcamento
{
    [Key]
    public int Id { get; set; }

    
    public string NomeCliente { get; set; }
    public DateTime DataCriacao { get; set; }
    public int StatusId { get; set; }
    public decimal ValorTotal { get; set; }
    

    public List<Produto> Produtos { get; set; }
    public List<Servico> Servicos { get; set; }
    public StatusOrcamento Status { get; set; }
}


