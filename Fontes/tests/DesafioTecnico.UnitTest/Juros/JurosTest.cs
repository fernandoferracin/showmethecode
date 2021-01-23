using DesafioTecnico.Business.Services;
using DesafioTecnico.Business.Notificacoes;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace DesafioTecnico.UnitTest.Juros
{
    public class JurosTest
    {
        [Fact(DisplayName = "Realizar e validar cálculo de juros com parâmetros válidos")]
        [Trait("Juros", "Calcular Juros")]
        public void CalcularJuros_ParametrosValidos_DeveCalcular()
        {
            Business.Models.Juros juros = DataCreatorJuros.PreencherEntidadeComValoresValidos();
            Task<Business.Models.Taxa> taxa = DataCreatorJuros.PreencherTaxaComValorValido();

            LogicCreatorJuros Creator = new LogicCreatorJuros()
                .ComStubObterTaxaJurosAtual(taxa);

            JurosService Logic = Creator.Instanciar();

            var resultado = Logic.CalcularJuros(juros);

            var valorFinal = juros.ValorInicial * Convert.ToDecimal(Math.Pow((Convert.ToDouble(taxa.Result.ValorTaxa) + 1), juros.Meses));            

            Creator._taxaService.Verify(p => p.ObterTaxaJurosAtual(), Times.Once);
            Creator._notificacao.Verify(p => p.Handle(It.IsAny<Notificacao>()), Times.Never);

            Assert.False(resultado.Result == null);
            Assert.Equal(valorFinal, resultado.Result.ValorFinal);
        }

        [Fact(DisplayName = "Não realizar cálculo com parâmetro taxa de juros inválido")]
        [Trait("Juros", "Calcular Juros")]
        public void CalcularJuros_ParametroTaxaInvalido_GravarNotificacao()
        {
            Business.Models.Juros juros = DataCreatorJuros.PreencherEntidadeComValoresValidos();
            Task<Business.Models.Taxa> taxa = DataCreatorJuros.PreencherTaxaComValorInvalido();

            LogicCreatorJuros Creator = new LogicCreatorJuros()
                .ComStubObterTaxaJurosAtual(taxa);

            JurosService Logic = Creator.Instanciar();

            var resultado = Logic.CalcularJuros(juros);

            Creator._taxaService.Verify(p => p.ObterTaxaJurosAtual(), Times.Once);
            Creator._notificacao.Verify(p => p.Handle(It.IsAny<Notificacao>()), Times.Once);

            Assert.True(resultado.Result == null);
        }

        [Fact(DisplayName = "Não realizar cálculo com parâmetro mês inválido")]
        [Trait("Juros", "Calcular Juros")]
        public void CalcularJuros_ParametroMesInvalido_GravarNotificacao()
        {
            Business.Models.Juros juros = DataCreatorJuros.PreencherEntidadeComMesInvalido();
            Task<Business.Models.Taxa> taxa = DataCreatorJuros.PreencherTaxaComValorValido();

            LogicCreatorJuros Creator = new LogicCreatorJuros()
                .ComStubObterTaxaJurosAtual(taxa);

            JurosService Logic = Creator.Instanciar();

            var resultado = Logic.CalcularJuros(juros);

            Creator._taxaService.Verify(p => p.ObterTaxaJurosAtual(), Times.Once);
            Creator._notificacao.Verify(p => p.Handle(It.IsAny<Notificacao>()), Times.Once);

            Assert.True(resultado.Result == null);
        }

        [Fact(DisplayName = "Não realizar cálculo com parâmetro valor inicial inválido")]
        [Trait("Juros", "Calcular Juros")]
        public void CalcularJuros_ParametroValorIncialInvalido_GravarNotificacao()
        {
            Business.Models.Juros juros = DataCreatorJuros.PreencherEntidadeComValorInicialInvalido();
            Task<Business.Models.Taxa> taxa = DataCreatorJuros.PreencherTaxaComValorValido();

            LogicCreatorJuros Creator = new LogicCreatorJuros()
                .ComStubObterTaxaJurosAtual(taxa);

            JurosService Logic = Creator.Instanciar();

            var resultado = Logic.CalcularJuros(juros);

            Creator._taxaService.Verify(p => p.ObterTaxaJurosAtual(), Times.Once);
            Creator._notificacao.Verify(p => p.Handle(It.IsAny<Notificacao>()), Times.Once);

            Assert.True(resultado.Result == null);
        }
    }
}
