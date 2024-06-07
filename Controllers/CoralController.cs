using gsnet.Data;
using gsnet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace gsnet.Controllers
{
    public class CoralController : Controller
    {
        private readonly DataContext _context;

        public CoralController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var corals = _context.Corais.ToList();
            return View(corals);
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coral = _context.Corais.FirstOrDefault(c => c.Id == id);
            if (coral == null)
            {
                return NotFound();
            }

            return View(coral);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Coral coral)
        {
            if (ModelState.IsValid)
            {
                _context.Add(coral);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(coral);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coral = _context.Corais.FirstOrDefault(c => c.Id == id);
            if (coral == null)
            {
                return NotFound();
            }
            return View(coral);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Coral coral)
        {
            if (id != coral.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(coral);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CoralExists(coral.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(coral);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coral = _context.Corais.FirstOrDefault(c => c.Id == id);
            if (coral == null)
            {
                return NotFound();
            }

            return View(coral);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var coral = _context.Corais.FirstOrDefault(c => c.Id == id);
            if (coral == null)
            {
                return NotFound();
            }

            _context.Corais.Remove(coral);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool CoralExists(int id)
        {
            return _context.Corais.Any(c => c.Id == id);
        }
    }
}
