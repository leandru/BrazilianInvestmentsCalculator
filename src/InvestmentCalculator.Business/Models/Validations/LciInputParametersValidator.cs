using FluentValidation;

namespace InvestmentCalculator.Business.Models.Validations
{
    public class LciInputParametersValidator : AbstractValidator<LciInputParameters>
    {
        public LciInputParametersValidator()
        {
            RuleFor(x => x.StartDate).NotEmpty().LessThanOrEqualTo(DateTime.Today);
            RuleFor(x => x.EndDate).NotEmpty().LessThanOrEqualTo(DateTime.Today);
            RuleFor(x => x.InvestmentAmount).NotEmpty();
            RuleFor(x => x.CdiPercentage).NotEmpty();
            RuleFor(x => x.StartDate).LessThan(x => x.EndDate);
        }
    }
}
