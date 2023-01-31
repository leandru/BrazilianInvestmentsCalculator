using InvestmentCalculator.Business.Interfaces;
using InvestmentCalculator.Business.Services;
using Microsoft.Extensions.Caching.Memory;

namespace InvestmentCalculator.API.Configuration;

public static class DependencyInjectionConfig
{
    public static IServiceCollection ResolveDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddHttpClient("CdiHistoricalAPI", client =>
        {
            client.BaseAddress = new Uri(configuration.GetSection("ExternalEndpointsOptions")["HistoralCdiIndexFeeUrl"]);
        });
        services.AddSingleton<IMemoryCache, MemoryCache>();
        services.AddScoped<IConsultationService, ConsultationService>();
        services.AddScoped<ICalculationService, CalculationService>();

        return services;
    }
}

