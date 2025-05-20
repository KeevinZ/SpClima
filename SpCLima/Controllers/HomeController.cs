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
    private readonly AppDbContext _db;

    public HomeController(ILogger<HomeController> logger, AppDbContext db)
    {
        _logger = logger;
        _db = db;
    }

    public IActionResult Index()
    {
        var destaques = _db.items
        .Where(i => i.Destaque)
        .Include(i => i.Variacoes)
        .AsNoTracking()
        .ToList();

        return View(destaques);
    }

    public IActionResult Item(int id)
    {
        // 1) Carrega o item principal com suas variações
        var item = _db.items
            .Include(i => i.Variacoes)
            .FirstOrDefault(i => i.Id == id);

        if (item == null)
            return NotFound();

        // 2) Carrega outros itens para sugerir na página de detalhes
        var outros = _db.items
            .Where(i => i.Id != id && i.Destaque)
            .Include(i => i.Variacoes)
            .AsNoTracking()
            .Take(4)
            .ToList();

        var vm = new ItemVM
        {
            Item = item,
            Outros = outros
        };

        return View(vm);
    }
    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult GaleriaOrcamento()
{
    // Carrega todos os itens com variações, agrupados por tipo/categoria
     var grupos = _db.items
        .Include(i => i.Variacoes)
        .AsNoTracking()
        .ToList()
        .GroupBy(i => i.Tipo)
        .Select(g => new GaleriaItemVM
        {
            Tipo  = g.Key.ToString(),
            Itens = g.ToList()
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
