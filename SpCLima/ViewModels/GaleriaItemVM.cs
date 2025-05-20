using SpClima.Models;

namespace SpClima.ViewModels;
public class GaleriaItemVM
{
    public string Tipo { get; set; }
    public List<Item> Itens { get; set; } = new();
}
