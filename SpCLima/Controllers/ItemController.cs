using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SpClima.Data;
using SpClima.Models;

namespace SpClima.Controllers
{
    [Authorize(Roles = "Administrador")]
    public class ItemsController : Controller
    {
        private readonly AppDbContext _db;
        public ItemsController(AppDbContext db) => _db = db;

        public async Task<IActionResult> Index()
        {
            var items = await _db.items.Include(i => i.Variacoes).ToListAsync();
            return View(items);
        }

        // Create
        public IActionResult Create() => View();

        // Create
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Item item)
        {
            if (!ModelState.IsValid)
                return View(item);

            _db.items.Add(item);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // Edit
        public async Task<IActionResult> Edit(int id)
        {
            var item = await _db.items.FindAsync(id);
            if (item == null) return NotFound();
            return View(item);
        }

        // Edit
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Item item)
        {
            if (id != item.Id) return BadRequest();
            if (!ModelState.IsValid) return View(item);

            _db.items.Update(item);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // Delete
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _db.items.FindAsync(id);
            if (item == null) return NotFound();
            return View(item);
        }

        //Delete
        [HttpPost, ValidateAntiForgeryToken, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var item = await _db.items.FindAsync(id);
            if (item != null)
            {
                _db.items.Remove(item);
                await _db.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}