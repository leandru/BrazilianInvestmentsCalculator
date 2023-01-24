using InvestmentCalculator.API.Configuration;
using InvestmentCalculator.API.Services;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json", true, true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", true, true)
    .AddEnvironmentVariables();

builder.Services.AddControllers();

builder.Services.AddHttpClient();
builder.Services.Configure<ExternalEndpointsOptions>(
    builder.Configuration.GetSection("ExternalEndpointsOptions"));

builder.Services.AddSwaggerConfig();

builder.Services.AddSingleton<CdiConsultationService>();
builder.Services.AddScoped<CdiAmountCorrectionService>();



var app = builder.Build();

var apiVersionDescriptionProvider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();
app.UseSwaggerConfig(apiVersionDescriptionProvider);


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
