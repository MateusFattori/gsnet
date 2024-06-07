using gsnet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;
using gsnet.Data;

namespace gsnet.Controllers
{
    public class CoralsController : Controller
    {
        private readonly DataContext _context;

        public CoralsController(DataContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var corals = await _context.Coralis.Include(c => c.Projeto).ToListAsync();
            return View(corals);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Coral coral)
        {
            if (ModelState.IsValid)
            {
                _context.Coralis.Add(coral);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(coral);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var coral = await _context.Coralis.FindAsync(id);
            if (coral == null)
            {
                return NotFound();
            }
            return View(coral);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Coral coral)
        {
            if (id != coral.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                _context.Update(coral);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(coral);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var coral = await _context.Coralis.FindAsync(id);
            if (coral == null)
            {
                return NotFound();
            }
            return View(coral);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var coral = await _context.Coralis.FindAsync(id);
            _context.Coralis.Remove(coral);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
