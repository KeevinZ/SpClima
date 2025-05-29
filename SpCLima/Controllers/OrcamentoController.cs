using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SpClima.Data;
using SpClima.ViewModels;

namespace SpClima.Controllers
{
    [Authorize(Roles = "Administrador")]
    public class OrcamentosController : Controller
    {
        private readonly AppDbContext _context;

        public OrcamentosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Orcamentos
        public async Task<IActionResult> Index()
        {
            var orcamentos = await _context.Orcamentos
                .Include(o => o.OrcamentoItems)
                    .ThenInclude(oi => oi.Variacao)
                        .ThenInclude(v => v.Item)
                .OrderByDescending(o => o.DataCriacao)
                .ToListAsync();

            ViewBag.TotalFaturado = orcamentos.Sum(o => o.ValorTotal);

            return View(orcamentos);
        }

        // GET: Details
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var orcamento = await _context.Orcamentos
                .Include(o => o.OrcamentoItems)
                    .ThenInclude(oi => oi.Variacao)
                        .ThenInclude(v => v.Item)
                .FirstOrDefaultAsync(o => o.Id == id);

            if (orcamento == null) return NotFound();

            return View(orcamento);
        }

        // GET: Estatisticas
        public async Task<IActionResult> Estatisticas()
        {
            var estatisticas = await _context.OrcamentoItems
                .Include(oi => oi.Variacao.Item)
                .GroupBy(oi => oi.Variacao.Item.Titulo)
                .Select(g => new EstatisticaVM
                {
                    Item = g.Key,
                    Quantidade = g.Count(),
                    Total = g.Sum(x => x.PrecoFinal ?? x.PrecoEstimado)
                })
                .OrderByDescending(e => e.Quantidade)
                .Take(5)
                .ToListAsync();

            ViewBag.FaturamentoTotal = await _context.Orcamentos.SumAsync(o => o.ValorTotal);

            return View(estatisticas);
        }
    }
}

