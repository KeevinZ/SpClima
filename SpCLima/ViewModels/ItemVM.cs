using SpClima.Models;

namespace SpClima.ViewModels;

public class ItemVM
{
     public Item Item { get; set; }
    public IEnumerable<Item> Outros { get; set; }
}
