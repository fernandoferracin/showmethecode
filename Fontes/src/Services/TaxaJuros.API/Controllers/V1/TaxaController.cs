using AutoMapper;
using DesafioTecnico.Business.Interfaces;
using DesafioTecnico.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TaxaJuros.API.ViewModel;

namespace TaxaJuros.API.Controllers.V1
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/taxaJuros")]
    public class TaxaController : MainController
    {
        private readonly IMapper _mapper;
        private readonly ITaxaService _taxaService;

        public TaxaController(ITaxaService taxaService,
                              IMapper mapper,
                              INotificador notificador) : base(notificador)
        {
            _taxaService = taxaService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<TaxaViewModel> ObterTaxaJurosAtual()
        {
            var taxa = _mapper.Map<TaxaViewModel>(await _taxaService.ObterTaxaJurosAtual());

            return taxa;
        }
    }
}
