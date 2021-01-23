using DesafioTecnico.Business.Interfaces;
using DesafioTecnico.Business.Models;
using DesafioTecnico.Business.Interfaces;
using System;
using System.Threading.Tasks;

namespace DesafioTecnico.Business.Services
{
    public class TaxaService : BaseService, ITaxaService
    {
        public TaxaService(INotificador notificador) : base(notificador) { }

        public async Task<Taxa> ObterTaxaJurosAtual()
        {
            return await BuscarTaxaAtual();
        }

        private Task<Taxa> BuscarTaxaAtual()
        {
            var taxa = new Taxa();
            taxa.ValorTaxa = Convert.ToDecimal(0.01);            

            return Task.FromResult<Taxa>(taxa);
        }

        public void Dispose() { }
    }
}