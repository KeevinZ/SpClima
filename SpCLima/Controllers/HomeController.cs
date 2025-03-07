using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
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
        List<Produto> produtos = _db.Produtos
        .Where(p => p.Destaque)
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
            .SingleOrDefault();

        ProdutoVM produtoVM = new()
        {
            Produto = produto
        };
        produtoVM.Produtos = _db.Produtos
             .Where(p => p.CategoriaId == produto.CategoriaId)
             .Take(4).ToList();

        return View(produtoVM);
    }
    public IActionResult TipoDeServico(int id)
    {
        TipoDeServico tipoDeServico = _db.TiposDeServicos
               .Where(t => t.TipoDeServicoId == id)
               .Include(t => t.Categoria)
               .SingleOrDefault();

        TipoDeServicoVM tipoDeServicoVM = new TipoDeServicoVM
        {
            TipoDeServico = tipoDeServico,
            TiposDeServicos = _db.TiposDeServicos
                .Where(t => t.CategoriaId == tipoDeServico.CategoriaId)
                .Take(4).ToList()
        };

        return View(tipoDeServicoVM);
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
