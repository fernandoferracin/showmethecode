using System;
using System.Threading.Tasks;
using DesafioTecnico.Business.Models;

namespace DesafioTecnico.Business.Interfaces
{
    public interface IJurosService : IDisposable
    {
        Task<Juros> CalcularJuros(Juros parametros);
    }
}