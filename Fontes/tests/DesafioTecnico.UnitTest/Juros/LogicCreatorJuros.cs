using DesafioTecnico.Business.Interfaces;
using DesafioTecnico.Business.Services;
using DesafioTecnico.Business.Interfaces;
using Moq;
using System.Threading.Tasks;

namespace DesafioTecnico.UnitTest.Juros
{
    public class LogicCreatorJuros
    {
        public Mock<IJurosService> _jurosService { get; }
        public Mock<ITaxaService> _taxaService { get; }
        public Mock<INotificador> _notificacao { get; }

        public LogicCreatorJuros()
        {
            _jurosService = new Mock<IJurosService>();
            _taxaService = new Mock<ITaxaService>();
            _notificacao = new Mock<INotificador>();
        }

        public JurosService Instanciar() => new JurosService(
            _taxaService.Object,
            _notificacao.Object
            );

        public LogicCreatorJuros ComStubObterTaxaJurosAtual(Task<Business.Models.Taxa> resultadoEsperado)
        {
            _taxaService.Setup(x => x.ObterTaxaJurosAtual()).Returns(resultadoEsperado);
            return this;
        }
    }
}
