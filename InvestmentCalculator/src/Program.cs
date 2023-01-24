using InvestmentCalculator.API.src.Configuration;
using InvestmentCalculator.API.src.Services;
using InvestmentCalculator.src.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Text.RegularExpressions;
using static InvestmentCalculator.API.src.Configuration.SwaggerConfig;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration
    .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "src"))
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

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
