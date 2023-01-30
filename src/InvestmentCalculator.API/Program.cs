using InvestmentCalculator.API.Configuration;
using InvestmentCalculator.Business.Interfaces;
using InvestmentCalculator.Business.Models;
using InvestmentCalculator.Business.Services;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json", true, true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", true, true)
    .AddEnvironmentVariables();

CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("pt-BR");
CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("pt-BR");

builder.Services.Configure<ExternalEndpoints>(builder.Configuration.GetSection("ExternalEndpointsOptions"));

builder.Services.AddControllers();

builder.Services.AddHttpClient("CdiHistoricalAPI", client =>
{
    client.BaseAddress = new Uri(builder.Configuration.GetSection("ExternalEndpointsOptions")["HistoralCdiIndexFeeUrl"]);
});

builder.Services.AddSwaggerConfig();

builder.Services.AddSingleton<IMemoryCache, MemoryCache>();
builder.Services.AddScoped<IConsultationService, ConsultationService>();
builder.Services.AddScoped<ICalculationService, CalculationService>();

builder.Services.AddFluentValidation();

var app = builder.Build();

var apiVersionDescriptionProvider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();
app.UseSwaggerConfig(apiVersionDescriptionProvider);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
