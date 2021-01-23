using DesafioTecnico.MVC.Extensions;
using DesafioTecnico.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace DesafioTecnico.MVC.Services
{
    public interface ITaxaService
    {
        Task<TaxaViewModel> ObterTaxaJurosAtual();
    }
    public class TaxaService : Service, ITaxaService
    {
        private readonly HttpClient _httpClient;

        public TaxaService(HttpClient httpClient,
                            IOptions<AppSettings> settings)
        {
            httpClient.BaseAddress = new Uri(settings.Value.TaxaJurosUrl);
            //httpClient.BaseAddress = new Uri("https://localhost:44396");

            _httpClient = httpClient;
        }

        public async Task<TaxaViewModel> ObterTaxaJurosAtual()
        {
            var response = await _httpClient.GetAsync($"/api/v1/taxaJuros/");

            if (response.StatusCode == HttpStatusCode.NotFound) return null;

            TratarErrosResponse(response);

            return await DeserializarObjetoResponse<TaxaViewModel>(response);
        }        
    }
}