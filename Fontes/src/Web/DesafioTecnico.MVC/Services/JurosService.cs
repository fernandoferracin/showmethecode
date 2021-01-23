using DesafioTecnico.MVC.Communication;
using DesafioTecnico.MVC.Extensions;
using DesafioTecnico.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace DesafioTecnico.MVC.Services
{
    public interface IJurosService
    {
        Task<ResponseResult<JurosViewModel>> CalcularJuros(JurosViewModel juros);
    }
    public class JurosService : Service, IJurosService
    {
        private readonly HttpClient _httpClient;

        public JurosService(HttpClient httpClient,
                            IOptions<AppSettings> settings)
        {
            httpClient.BaseAddress = new Uri(settings.Value.CalculaJurosUrl);
            //httpClient.BaseAddress = new Uri("https://localhost:44362");

            _httpClient = httpClient;
        }

        public async Task<ResponseResult<JurosViewModel>> CalcularJuros(JurosViewModel juros)
        {
            var jurosContent = ObterConteudo(juros);

            var response = await _httpClient.PostAsync($"/api/v1/calculajuros", jurosContent);

            if (!TratarErrosResponse(response))
            {
                return await DeserializarObjetoResponse<ResponseResult<JurosViewModel>>(response);
            }

            return await DeserializarObjetoResponse<ResponseResult<JurosViewModel>>(response);
        }
    }
}