using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SpClima.Data;
using SpClima.Models;



public class HomeController : Controller
{
    private readonly AppDbContext _db;

    public HomeController(AppDbContext db)
    {
        _db = db;
    }

    // Página inicial lista serviços com eletrodomésticos
    public IActionResult Index()
    {
        var servicos = _db.Servicos
            .Include(s => s.Eletrodomestico)  // Carrega o relacionamento
            .ToList();

        return View(servicos);
    }

    // Detalhes de um serviço específico
    public IActionResult DetalhesServico(int id)
    {
        var servico = _db.Servicos
            .Include(s => s.Eletrodomestico)
            .FirstOrDefault(s => s.Id == id);

        if (servico == null)
        {
            return NotFound();
        }

        return View(servico);
    }

    // Lista serviços por tipo de eletrodoméstico
    public IActionResult ServicosPorEletrodomestico(int eletrodomesticoId)
    {
        var servicos = _db.Servicos
            .Where(s => s.EletrodomesticoId == eletrodomesticoId)
            .Include(s => s.Eletrodomestico)
            .ToList();

        ViewBag.Eletrodomestico = _db.Eletrodomesticos
            .FirstOrDefault(e => e.Id == eletrodomesticoId)?.Tipo;

        return View(servicos);
    }
}
