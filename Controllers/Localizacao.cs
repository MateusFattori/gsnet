using gsnet.Models;
using gsnet.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace gsnet.Controllers
{
    public class LocalizacaoController : Controller
    {
        private readonly ILocalizacaoService _localizacaoService;

        public LocalizacaoController(ILocalizacaoService localizacaoService)
        {
            _localizacaoService = localizacaoService;
        }
        public async Task<IActionResult> Index()
        {
            var localizacoes = await _localizacaoService.GetAllLocalizacoesAsync();
            return View(localizacoes);
        }

        public async Task<IActionResult> Details(int id)
        {
            var localizacao = await _localizacaoService.GetLocalizacaoByIdAsync(id);
            if (localizacao == null)
            {
                return NotFound();
            }
            return View(localizacao);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Localizacao localizacao)
        {
            if (ModelState.IsValid)
            {
                await _localizacaoService.CreateLocalizacaoAsync(localizacao);
                return RedirectToAction(nameof(Index));
            }
            return View(localizacao);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var localizacao = await _localizacaoService.GetLocalizacaoByIdAsync(id);
            if (localizacao == null)
            {
                return NotFound();
            }
            return View(localizacao);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Localizacao localizacao)
        {
            if (id != localizacao.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                await _localizacaoService.UpdateLocalizacaoAsync(localizacao);
                return RedirectToAction(nameof(Index));
            }
            return View(localizacao);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var localizacao = await _localizacaoService.GetLocalizacaoByIdAsync(id);
            if (localizacao == null)
            {
                return NotFound();
            }
            return View(localizacao);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _localizacaoService.DeleteLocalizacaoAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
