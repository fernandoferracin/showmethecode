using Microsoft.AspNetCore.Mvc;

namespace DesafioTecnico.MVC.Extensions
{
    public class SummaryViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}