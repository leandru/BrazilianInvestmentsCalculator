using FluentValidation;

namespace InvestmentCalculator.API.Models.Validations
{
    public class CdiInputParametersValidator : AbstractValidator<CdiInputParameters>
    {
        public CdiInputParametersValidator()
        {
            RuleFor(x => x.StartDate).NotEmpty().LessThanOrEqualTo(DateTime.Today);
            RuleFor(x => x.EndDate).NotEmpty().LessThanOrEqualTo(DateTime.Today);
            RuleFor(x => x.InvestmentAmount).NotEmpty();
            RuleFor(x => x.CdiPercentage).NotEmpty();
            RuleFor(x => x.StartDate).LessThan(x => x.EndDate);
        }
    }
}
