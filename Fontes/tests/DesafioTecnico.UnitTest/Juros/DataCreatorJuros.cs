using System.Threading.Tasks;

namespace DesafioTecnico.UnitTest.Juros
{
    public static class DataCreatorJuros
    {
        public static Business.Models.Juros PreencherEntidadeComValoresValidos()
        {
            return new Business.Models.Juros()
            {
                Meses = 5,
                ValorInicial = 100
            };
        }
        public static Business.Models.Juros PreencherEntidadeComMesInvalido()
        {
            return new Business.Models.Juros()
            {
                ValorInicial = 100
            };
        }
        public static Business.Models.Juros PreencherEntidadeComValorInicialInvalido()
        {
            return new Business.Models.Juros()
            {
                Meses = 5,
            };
        }
        public static Task<Business.Models.Taxa> PreencherTaxaComValorValido()
        {
            return Task.FromResult(new Business.Models.Taxa()
            {
                ValorTaxa = 0.05m
            });
        }
        public static Task<Business.Models.Taxa> PreencherTaxaComValorInvalido()
        {
            return Task.FromResult(new Business.Models.Taxa()
            {
                ValorTaxa = 0
            });
        }
    }
}
