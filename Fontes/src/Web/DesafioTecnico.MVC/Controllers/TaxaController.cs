using DesafioTecnico.MVC.Models;
using DesafioTecnico.MVC.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DesafioTecnico.MVC.Controllers
{
    public class TaxaController : MainController<TaxaViewModel>
    {
        private readonly ITaxaService _taxaService;

        public TaxaController(ITaxaService taxaService)
        {
            _taxaService = taxaService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var taxa = await _taxaService.ObterTaxaJurosAtual();

            return View(taxa);
        }
    }
}
