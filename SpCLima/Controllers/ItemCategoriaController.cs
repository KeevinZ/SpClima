using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SpClima.Data;
using SpClima.Models;

namespace SpClima.Controllers
{
    [Authorize(Roles = "Administrador")]
    public class ItemCategoriasController : Controller
    {
        private readonly AppDbContext _context;

        public ItemCategoriasController(AppDbContext context)
        {
            _context = context;
        }

        // GET: ItemCategorias
        public async Task<IActionResult> Index()
        {
            return View(await _context.ItemCategorias.ToListAsync());
        }

        // GET: ItemCategorias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var categoria = await _context.ItemCategorias
                .FirstOrDefaultAsync(m => m.Id == id);
                
            if (categoria == null) return NotFound();

            return View(categoria);
        }

        // GET: ItemCategorias/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ItemCategorias/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome")] ItemCategoria categoria)
        {
            if (ModelState.IsValid)
            {
                _context.Add(categoria);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(categoria);
        }

        // GET: ItemCategorias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var categoria = await _context.ItemCategorias.FindAsync(id);
            if (categoria == null) return NotFound();
            
            return View(categoria);
        }

        // POST: ItemCategorias/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome")] ItemCategoria categoria)
        {
            if (id != categoria.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(categoria);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoriaExists(categoria.Id))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(categoria);
        }

        // GET: ItemCategorias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var categoria = await _context.ItemCategorias
                .FirstOrDefaultAsync(m => m.Id == id);
                
            if (categoria == null) return NotFound();
            
            // Verificar se existem itens vinculados
            var itensVinculados = await _context.items
                .AnyAsync(i => i.ItemCategoriaId == id);
                
            ViewBag.ItensVinculados = itensVinculados;
            
            return View(categoria);
        }

        // POST: ItemCategorias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var categoria = await _context.ItemCategorias.FindAsync(id);
            
            // Verificar se existem itens vinculados
            var itensVinculados = await _context.items
                .AnyAsync(i => i.ItemCategoriaId == id);
                
            if (itensVinculados)
            {
                ModelState.AddModelError("", "Não é possível excluir a categoria pois existem itens vinculados a ela.");
                ViewBag.ItensVinculados = true;
                return View("Delete", categoria);
            }
            
            _context.ItemCategorias.Remove(categoria);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoriaExists(int id)
        {
            return _context.ItemCategorias.Any(e => e.Id == id);
        }
    }
}