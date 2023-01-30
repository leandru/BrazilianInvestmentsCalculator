using InvestmentCalculator.Business.Models;
using InvestmentCalculator.Business.Services;
using InvestmentCalculator.Tests.Utils;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.VisualBasic;
using Moq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace InvestmentCalculator.Tests.Units
{
    public class ConsultationServiceTests
    {
        private readonly Mock<IHttpClientFactory> _httpClientFactoryMock;
        private readonly Mock<MemoryCache> _memoryCacheMock;

        private const string CDI_API_URL = "https://api.bcb.gov.br/dados/serie/bcdata.sgs.12/dados?formato=json";

        public ConsultationServiceTests()
        {
            _httpClientFactoryMock = new Mock<IHttpClientFactory>();
            _memoryCacheMock = new Mock<MemoryCache>(new MemoryCacheOptions());
        }

        [Fact]
        public async Task GetCDIHistoricalSeries_ShouldReturnKnownData()
        {
            var httpClient = new HttpClient() { BaseAddress = new Uri(CDI_API_URL) };

            _httpClientFactoryMock.Setup(x => x.CreateClient("CdiHistoricalAPI"))
                       .Returns(httpClient);

            var consultationService = new ConsultationService(_httpClientFactoryMock.Object, _memoryCacheMock.Object);

            var result = await consultationService.GetCDIHistoricalSeries();
            var knownResults = MockedValues.GetCdiDaysList();
            Assert.NotNull(result);

            bool hasMatch = result
                          .Intersect(knownResults)
                          .Any();

            Assert.True(hasMatch);
        }       
    }
}
