using DesafioTecnico.MVC.Communication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Linq;

namespace DesafioTecnico.MVC.Controllers
{
    public class MainController<T> : Controller
    {
        protected bool ResponsePossuiErros(ResponseResult<T> resposta)
        {
            if (resposta != null && resposta.Errors != null)
            {
                ModelState.Clear();
                foreach (var mensagem in resposta.Errors)
                {
                    ModelState.AddModelError(string.Empty, mensagem);
                }

                return true;
            }

            return false;
        }

        protected void AdicionarErroValidacao(string mensagem)
        {
            ModelState.AddModelError(string.Empty, mensagem);
        }

        protected bool OperacaoValida()
        {
            return ModelState.ErrorCount == 0;
        }
    }
}