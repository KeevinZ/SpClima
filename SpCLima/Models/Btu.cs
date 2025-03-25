using System.ComponentModel.DataAnnotations.Schema;


namespace SpCLima.Models;

[Table("btu")]
public class Btu
{
    public int Id { get; set; }
    public int Valor { get; set; } // Ex: 9000, 12000, 18000
    public string Categoria { get; set; } // Ex: "Pequeno", "Médio", "Grande"
    public decimal CustoInstalacaoBase { get; set; } // Custo base associado ao BTU
}