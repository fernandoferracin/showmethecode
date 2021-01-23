using System.Collections.Generic;

namespace DesafioTecnico.Business.Models
{
    public class Juros : Entity
    {
        public decimal ValorInicial { get; set; }

        public int Meses { get; set; }

        public decimal ValorFinal { get; set; }

        public Taxa Taxa { get; set; }
    }
}
