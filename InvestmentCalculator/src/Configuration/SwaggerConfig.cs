using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Text.Json;

namespace InvestmentCalculator.API.src.Configuration
{
    public static class SwaggerConfig
    {
        public static IServiceCollection AddSwaggerConfig(this IServiceCollection services)
        {
            services.AddApiVersioning(options =>
            {
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.ReportApiVersions = true;
            });

            services.AddVersionedApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;

            });
            services.AddSwaggerGen(c =>
            {
                c.OperationFilter<SwaggerDefaultValues>();

            });

            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

            return services;
        }
        public static IApplicationBuilder UseSwaggerConfig(this IApplicationBuilder app, IApiVersionDescriptionProvider provider)
        {
            app.UseSwagger();
            app.UseSwaggerUI(
                options =>
                {
                    foreach (var description in provider.ApiVersionDescriptions)
                    {
                        options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
                    }
                });
            return app;
        }

        public class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
        {
            readonly IApiVersionDescriptionProvider provider;

            public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider) => this.provider = provider;

            public void Configure(SwaggerGenOptions options)
            {
                foreach (var description in provider.ApiVersionDescriptions)
                {
                    options.SwaggerDoc(description.GroupName, CreateInfoForApiVersion(description));
                }
            }

            static OpenApiInfo CreateInfoForApiVersion(ApiVersionDescription description)
            {
                var descriptionText = @"This API helps to calc Brazilian Investments <br/>  <br/>
                                        <b>LCI</b> </br>
                                        Calculation Methodology: <a target='_blank' href='https://www.b3.com.br/pt_br/market-data-e-indices/indices/indices-de-segmentos-e-setoriais/di/metodologia-de-calcudo-acumulado-de-di/'> B3 Methodology </a><br/>
                                        Based on: <a target='_blank' href='https://www3.bcb.gov.br/CALCIDADAO/publico/exibirFormCorrecaoValores.do?method=exibirFormCorrecaoValores&aba=5'> BACEN DI Calculator </a><br/>
                                        Data retrieved from: <a target='_blank' href='https://api.bcb.gov.br/dados/serie/bcdata.sgs.12/dados?formato=json'> Bacen DI Data </a> <br/>";
                var info = new OpenApiInfo()
                {
                    Title = "Brazilian Investment Calculator",
                    Version = description.ApiVersion.ToString(),
                    Description = descriptionText,  
                    Contact = new OpenApiContact() { Name = "Leandro Almeida", Email = "leandrualmeida@gmail.com" },
                    License = new OpenApiLicense() { Name = "MIT", Url = new Uri("https://opensource.org/licenses/MIT") }
                };

                if (description.IsDeprecated)
                {
                    info.Description += " It's an obsoleted version!";
                }

                return info;
            }
        }

        public class SwaggerDefaultValues : IOperationFilter
        {
            public void Apply(OpenApiOperation operation, OperationFilterContext context)
            {
                var apiDescription = context.ApiDescription;

                operation.Deprecated |= apiDescription.IsDeprecated();

                foreach (var responseType in context.ApiDescription.SupportedResponseTypes)
                {
                    var responseKey = responseType.IsDefaultResponse ? "default" : responseType.StatusCode.ToString();
                    var response = operation.Responses[responseKey];

                    foreach (var contentType in response.Content.Keys)
                        if (responseType.ApiResponseFormats.All(x => x.MediaType != contentType))
                            response.Content.Remove(contentType);
                }

                if (operation.Parameters == null)
                    return;

                foreach (var parameter in operation.Parameters)
                {
                    var description = apiDescription.ParameterDescriptions.First(p => p.Name == parameter.Name);

                    parameter.Description ??= description.ModelMetadata.Description;

                    if (parameter.Schema.Default == null && description.DefaultValue != null)
                    {
                        var json = JsonSerializer.Serialize(description.DefaultValue, description.ModelMetadata.ModelType);
                        parameter.Schema.Default = OpenApiAnyFactory.CreateFromJson(json);
                    }

                    parameter.Required |= description.IsRequired;
                }
            }
        }
    }
}
