using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SpClima.Data;
using SpClima.Models;

namespace SpClima.Controllers
{
    [Authorize(Roles = "Administrador")]
    public class ItemsController : Controller
    {
        private readonly AppDbContext _context;

        public ItemsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Items
        public async Task<IActionResult> Index()
        {
            var items = await _context.items
                .Include(i => i.Categoria)
                .Include(i => i.Variacoes)
                .ToListAsync();
            return View(items);
        }

        // GET: Create
        public IActionResult Create()
        {
            ViewData["CategoriaId"] = new SelectList(_context.ItemCategorias, "Id", "Nome");
            return View(new Item { Variacoes = new List<ItemVariacao>() });
        }

        // POST: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("Id,Titulo,Descricao,CategoriaId,Destaque,ImagemUrl")] Item item,
            List<ItemVariacao> variacoes)
        {
            // Validação: deve ter pelo menos uma variação
            if (variacoes.Count == 0 || variacoes.Any(v => string.IsNullOrWhiteSpace(v.Nome)))
            {
                ModelState.AddModelError("", "Pelo menos uma variação válida é obrigatória");
            }

            if (ModelState.IsValid)
            {
                _context.Add(item);
                await _context.SaveChangesAsync();

                // Adiciona variações
                foreach (var variacao in variacoes)
                {
                    if (!string.IsNullOrWhiteSpace(variacao.Nome))
                    {
                        variacao.ItemId = item.Id;
                        _context.Add(variacao);
                    }
                }
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            ViewData["CategoriaId"] = new SelectList(_context.ItemCategorias, "Id", "Nome", item.ItemCategoriaId);
            item.Variacoes = variacoes;
            return View(item);
        }

        // GET: Items/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var item = await _context.items
                .Include(i => i.Variacoes)
                .FirstOrDefaultAsync(i => i.Id == id);

            if (item == null) return NotFound();

            // Garante que itens sem variações tenham pelo menos uma
            if (item.Variacoes.Count == 0)
            {
                item.Variacoes.Add(new ItemVariacao { Nome = "Padrão" });
            }

            ViewData["CategoriaId"] = new SelectList(_context.ItemCategorias, "Id", "Nome", item.ItemCategoriaId);
            return View(item);
        }

        // POST: Items/Edit/5
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Item item)
        {
            if (item == null || !ModelState.IsValid)
            {
                // Recarrega categorias e devolve view em caso de erro
                ViewData["ItemCategoriaId"] = new SelectList(_context.ItemCategorias, "Id", "Nome", item.ItemCategoriaId);
                return View(item);
            }

            // Atualiza campos do Item
            _context.Update(item);

            // Para cada variação:
            foreach (var vari in item.Variacoes)
            {
                if (vari.Id == 0)
                {
                    // nova variação
                    vari.ItemId = item.Id;
                    _context.Add(vari);
                }
                else
                {
                    // existente: atualiza preço/nome
                    _context.Entry(vari).State = EntityState.Modified;
                }
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _context.items
                .Include(i => i.Categoria)
                .Include(i => i.Variacoes)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (item == null)
            {
                return NotFound();
            }

            // Garante que itens sem variações tenham pelo menos uma
            if (item.Variacoes.Count == 0)
            {
                item.Variacoes.Add(new ItemVariacao { Nome = "Padrão" });
            }

            return View(item);
        }

        // GET: Items/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _context.items
                .Include(i => i.Categoria)
                .Include(i => i.Variacoes) // Carrega as variações
                .FirstOrDefaultAsync(m => m.Id == id);

            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        // POST: Items/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var item = await _context.items
                .Include(i => i.Variacoes) // Carrega as variações para remover junto
                .FirstOrDefaultAsync(i => i.Id == id);

            if (item != null)
            {
                // Remove todas as variações primeiro
                _context.ItemVariacoes.RemoveRange(item.Variacoes);


                _context.items.Remove(item);

                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }
        private bool ItemExists(int id)
        {
            return _context.items.Any(e => e.Id == id);
        }
    }
}