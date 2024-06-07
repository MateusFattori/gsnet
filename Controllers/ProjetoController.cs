using gsnet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;
using gsnet.Data;

namespace gsnet.Controllers
{
    public class ProjetosController : Controller
    {
        private readonly DataContext _context;

        public ProjetosController(DataContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var projetos = await _context.Projetos.Include(p => p.Corais).ToListAsync();
            return View(projetos);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Projeto projeto)
        {
            if (ModelState.IsValid)
            {
                _context.Projetos.Add(projeto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(projeto);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var projeto = await _context.Projetos.FindAsync(id);
            if (projeto == null)
            {
                return NotFound();
            }
            return View(projeto);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Projeto projeto)
        {
            if (id != projeto.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                _context.Update(projeto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(projeto);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var projeto = await _context.Projetos.FindAsync(id);
            if (projeto == null)
            {
                return NotFound();
            }
            return View(projeto);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var projeto = await _context.Projetos.FindAsync(id);
            _context.Projetos.Remove(projeto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
