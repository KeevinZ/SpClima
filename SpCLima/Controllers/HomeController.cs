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

    public IActionResult Privacy()
    {
        return View();
    }

public IActionResult GaleriaOrcamento()
{
    var grupos = _db.items
        .Include(i => i.Variacoes)
        .AsNoTracking()
        .ToList()
        .GroupBy(i => i.Tipo)
        .Select(g => new GaleriaVM
        {
            Tipo = g.Key.ToString(),
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
