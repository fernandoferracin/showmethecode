using AutoMapper;
using CalculaJuros.API.ViewModel;
using DesafioTecnico.Business.Interfaces;
using DesafioTecnico.Business.Models;
using DesafioTecnico.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CalculaJuros.API.Controllers.V1
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/calculajuros")]
    public class JurosController : MainController
    {
        private readonly IMapper _mapper;
        private readonly IJurosService _jurosService;

        public JurosController(IJurosService jurosService,
                               IMapper mapper,
                               INotificador notificador) : base(notificador)
        {
            _jurosService = jurosService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<JurosViewModel>> CalcularJuros(JurosViewModel fornecedorViewModel)
        {
            fornecedorViewModel = _mapper.Map<JurosViewModel>(await _jurosService.CalcularJuros(_mapper.Map<Juros>(fornecedorViewModel)));

            if (!OperacaoValida()) return CustomResponse(fornecedorViewModel);

            return CustomResponse(fornecedorViewModel);
        }
    }
}
