using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SpClima.Data;
using SpClima.Models;
using SpClima.ViewModels;

namespace SpClima.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly AppDbContext _context; 

    public HomeController(ILogger<HomeController> logger, AppDbContext context)
    {
        _logger = logger;
        _context = context; 
    }

    public IActionResult Index()
    {
        var destaques = _context.items
            .Where(i => i.Destaque)
            .Include(i => i.Variacoes) 
            .AsNoTracking()
            .ToList();

        return View(destaques);
    }

    public IActionResult GaleriaOrcamento()
    {
        var grupos = _context.items
            .Include(i => i.Categoria) 
            .Include(i => i.Variacoes)
            .AsNoTracking()
            .ToList()
            .GroupBy(i => i.Categoria.Nome)
            .Select(g => new GaleriaVM
            {
                Tipo = g.Key, 
                Items = g.ToList()
            })
            .ToList();

        return View(grupos);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
