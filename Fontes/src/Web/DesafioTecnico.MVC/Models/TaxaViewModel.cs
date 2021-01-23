using System.ComponentModel;

namespace DesafioTecnico.MVC.Models
{
    public class TaxaViewModel
    {
        [DisplayName("Valor Taxa")]
        public decimal ValorTaxa { get; set; }
    }
}
