using DesafioTecnico.MVC.Extensions;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DesafioTecnico.MVC.Models
{
    public class JurosViewModel
    {
        [Moeda]
        [DisplayName("Valor Inicial")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public decimal ValorInicial { get; set; }

        [DisplayName("Meses")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int Meses { get; set; }

        [DisplayName("Valor Juros")]
        public decimal ValorTaxaJuros { get; set; }

        [DisplayName("Valor Final")]
        public decimal ValorFinal { get; set; }
    }
}
