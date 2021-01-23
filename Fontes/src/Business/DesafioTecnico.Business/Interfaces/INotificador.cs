using System.Collections.Generic;
using DesafioTecnico.Business.Notificacoes;

namespace DesafioTecnico.Business.Interfaces
{
    public interface INotificador
    {
        bool TemNotificacao();
        List<Notificacao> ObterNotificacoes();
        void Handle(Notificacao notificacao);
    }
}
