using FluentValidation;

namespace DesafioTecnico.Business.Models.Validations
{
    public class JurosValidation : AbstractValidator<Juros>
    {
        public JurosValidation()
        {
            RuleFor(c => c.ValorInicial)
                .GreaterThan(0).WithMessage("O campo {PropertyName} precisa ser maior que {ComparisonValue}");

            RuleFor(c => c.Meses)
                .GreaterThan(0).WithMessage("O campo {PropertyName} precisa ser maior que {ComparisonValue}");

            RuleFor(customer => customer.Taxa).SetValidator(new TaxaValidation());
        }
    }
}