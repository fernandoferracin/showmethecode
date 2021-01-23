using System;
using System.Threading.Tasks;
using DesafioTecnico.Business.Interfaces;
using DesafioTecnico.Business.Models;
using DesafioTecnico.Business.Models.Validations;
using DesafioTecnico.Business.Interfaces;

namespace DesafioTecnico.Business.Services
{
    public class JurosService : BaseService, IJurosService
    {
        private readonly ITaxaService _taxaService;
        public JurosService(ITaxaService taxaService,
                            INotificador notificador) : base(notificador)
        {
            _taxaService = taxaService;
        }

        public async Task<Juros> CalcularJuros(Juros parametros)
        {
            parametros.Taxa = new Taxa() { ValorTaxa = this.ObterTaxaJurosAtual() };

            if (!ExecutarValidacao(new JurosValidation(), parametros)) return null;

            var potencia = this.CalcularPotencia(parametros.Meses, Convert.ToDouble(parametros.Taxa.ValorTaxa));
            parametros.ValorFinal = (parametros.ValorInicial * potencia);

            return await Task.FromResult<Juros>(parametros);
        }

        private decimal CalcularPotencia(int meses, double taxa)
        {
            var potencia = Math.Pow((taxa + 1), meses);

            return Convert.ToDecimal(potencia);
        }

        private Decimal ObterTaxaJurosAtual()
        {
            var _taxa = _taxaService.ObterTaxaJurosAtual();

            return _taxa == null ? 0 : _taxa.Result.ValorTaxa;
        }

        public void Dispose() { }
    }
}