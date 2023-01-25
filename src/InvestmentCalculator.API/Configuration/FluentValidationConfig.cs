using FluentValidation;
using FluentValidation.Results;
using InvestmentCalculator.API.Models;
using InvestmentCalculator.API.Models.Validations;
using System;

namespace InvestmentCalculator.API.Configuration
{
    public static class FluentValidationConfig
    {
        public static IServiceCollection AddFluentValidation(this IServiceCollection services)
        {
            services.AddValidatorsFromAssemblyContaining<CdiInputParametersValidator>();
            services.AddScoped<IValidator<CdiInputParameters>, CdiInputParametersValidator>();

            return services;
        }

        public static List<MessageResult>? GetErrors(this ValidationResult result)
        {
            return result.Errors?.Select(error => new MessageResult(error.PropertyName, error.ErrorMessage)).ToList();
        }
    }
}
