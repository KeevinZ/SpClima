using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SpClima.Models;
using SpClima.Data;
using Microsoft.EntityFrameworkCore;
using SpClima.ViewModels;

namespace SpClima.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly AppDbContext _db;

    public HomeController(
        ILogger<HomeController> logger,
        AppDbContext db
    )
    {
        _logger = logger;
        _db = db;
    }

    public IActionResult Index()
    {
        List<Produto> produtos = _db.Produtos
            .Include(p => p.Fotos)
            .ToList();
        return View(produtos);
    }

    public IActionResult Produto(int id)
    {
        Produto produto = _db.Produtos
            .Where(p => p.Id == id)
            .Include(p => p.Categoria)
            .Include(p => p.Fotos)
            .Include(p => p.Servico)
            .SingleOrDefault();
        
        ProdutoVM produtoVM = new()
        {
            Produto = produto
        };

        produtoVM.Produtos = _db.Produtos
            .Where(p => p.CategoriaId == produto.CategoriaId
                && p.Id != produto.Id)
            .Take(4)
            .Include(p => p.Fotos)
            .ToList();

        return View(produtoVM);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}