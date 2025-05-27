using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SpClima.Data;

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

        // GET: /Orcamentos
        // Lista todos os orçamentos com itens e variações
        public async Task<IActionResult> Index()
        {
            var lista = await _context.Orcamentos
                .Include(o => o.OrcamentoItems)
                    .ThenInclude(oi => oi.Item)
                .Include(o => o.OrcamentoItems)
                    .ThenInclude(oi => oi.Variacao)
                .ToListAsync();

            return View(lista);
        }

        // Mostra detalhes de um único orçamento
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var orcamento = await _context.Orcamentos
                .Include(o => o.OrcamentoItems)
                    .ThenInclude(oi => oi.Item)
                .Include(o => o.OrcamentoItems)
                    .ThenInclude(oi => oi.Variacao)
                .FirstOrDefaultAsync(o => o.Id == id);

            if (orcamento == null)
                return NotFound();

            return View(orcamento);
        }
    }
}

