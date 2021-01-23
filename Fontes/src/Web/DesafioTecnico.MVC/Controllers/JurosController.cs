using DesafioTecnico.MVC.Models;
using DesafioTecnico.MVC.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DesafioTecnico.MVC.Controllers
{
    public class JurosController :  MainController<JurosViewModel>
    {
        private readonly IJurosService _jurosService;

        public JurosController(IJurosService jurosService) 
        {
            _jurosService = jurosService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(JurosViewModel jurosViewModel)
        {
            var resposta = await _jurosService.CalcularJuros(jurosViewModel);

            if (ResponsePossuiErros(resposta)) return View("Index", new JurosViewModel());

            return View("Index", resposta.Data);
        }
    }
}
