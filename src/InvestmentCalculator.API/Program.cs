using InvestmentCalculator.API.Configuration;
using InvestmentCalculator.Business.Interfaces;
using InvestmentCalculator.Business.Models;
using InvestmentCalculator.Business.Services;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
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

builder.Services.AddHttpClient();

builder.Services.AddSwaggerConfig();

builder.Services.AddSingleton<IConsultationService, ConsultationService>();
builder.Services.AddScoped<ICalculationService, CalculationService>();

builder.Services.AddFluentValidation();

var app = builder.Build();

var apiVersionDescriptionProvider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();
app.UseSwaggerConfig(apiVersionDescriptionProvider);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
