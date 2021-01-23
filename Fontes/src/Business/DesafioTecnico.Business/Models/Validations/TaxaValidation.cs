using FluentValidation;

namespace DesafioTecnico.Business.Models.Validations
{
    public class TaxaValidation : AbstractValidator<Taxa>
    {
        public TaxaValidation()
        {           
            RuleFor(c => c.ValorTaxa)
                .GreaterThan(0).WithMessage("O campo {PropertyName} precisa ser maior que {ComparisonValue}");
        }
    }
}