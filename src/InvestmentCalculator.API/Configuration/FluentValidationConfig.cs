using FluentValidation;
using FluentValidation.Results;
using InvestmentCalculator.Business.Models;
using InvestmentCalculator.Business.Models.Validations;
using InvestmentCalculator.API.ViewModels;

namespace InvestmentCalculator.API.Configuration
{
    public static class FluentValidationConfig
    {
        public static IServiceCollection AddFluentValidation(this IServiceCollection services)
        {
            services.AddValidatorsFromAssemblyContaining<LciInputParametersValidator>();
            services.AddScoped<IValidator<LciInputParameters>, LciInputParametersValidator>();

            return services;
        }

        public static List<MessageResult>? GetErrors(this ValidationResult result)
        {
            return result.Errors?.Select(error => new MessageResult(error.PropertyName, error.ErrorMessage)).ToList();
        }
    }
}
