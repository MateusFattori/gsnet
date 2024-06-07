using gsnet.Data;
using gsnet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace gsnet.Controllers
{
    public class ProjetoController : Controller
    {
        private readonly DataContext _context;

        public ProjetoController(DataContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var projetos = await _context.Projetos.ToListAsync();
            return View(projetos);
        }

        public async Task<IActionResult> Details(int id)
        {
            var projeto = await _context.Projetos.FirstOrDefaultAsync(p => p.Id == id);
            if (projeto == null) return NotFound();
            return View(projeto);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Projeto projeto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(projeto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(projeto);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var projeto = await _context.Projetos.FindAsync(id);
            if (projeto == null) return NotFound();
            return View(projeto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Projeto projeto)
        {
            if (id != projeto.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(projeto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjetoExists(projeto.Id)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(projeto);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var projeto = await _context.Projetos.FirstOrDefaultAsync(p => p.Id == id);
            if (projeto == null) return NotFound();
            return View(projeto);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var projeto = await _context.Projetos.FindAsync(id);
            _context.Projetos.Remove(projeto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProjetoExists(int id)
        {
            return _context.Projetos.Any(p => p.Id == id);
        }
    }
}
