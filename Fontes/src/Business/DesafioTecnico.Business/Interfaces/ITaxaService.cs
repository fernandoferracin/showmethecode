using System;
using System.Threading.Tasks;
using DesafioTecnico.Business.Models;

namespace DesafioTecnico.Business.Interfaces
{
    public interface ITaxaService : IDisposable
    {
        Task<Taxa> ObterTaxaJurosAtual();
    }
}