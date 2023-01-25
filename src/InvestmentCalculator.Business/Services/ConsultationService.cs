using InvestmentCalculator.Business.Models;
using InvestmentCalculator.Business.Interfaces;
using Microsoft.Extensions.Options;
using System.Data;
using System.Text.Json;

namespace InvestmentCalculator.Business.Services
{
    public class ConsultationService: IConsultationService
    {
        private readonly HttpClient _httpClient;
        private readonly ExternalEndpoints _externalEndPoints;
        private IEnumerable<CdiDay>? _cdiHistoricalSeries;

        public ConsultationService(HttpClient httpClient, IOptions<ExternalEndpoints> externalEndPoints)
        {
            _httpClient = httpClient;
            _externalEndPoints = externalEndPoints.Value;
        }

        public async Task<IEnumerable<CdiDay>> GetCDIHistoricalSeries()
        {
            if (_cdiHistoricalSeries is null)
            {
                var response = await GetHistoricalSeriesResponse(_externalEndPoints.HistoralCdiIndexFeeUrl);
                _cdiHistoricalSeries = JsonSerializer.Deserialize<IEnumerable<CdiDay>>(response);                
            }

            return _cdiHistoricalSeries;
        }

        public async Task<IEnumerable<CdiDay>> GetCDIHistoricalSeries(DateTime startDate, DateTime endDate)
        {
            var cdiHistoricalSeries = await GetCDIHistoricalSeries();
            var result = _cdiHistoricalSeries.Where(x => DateTime.Parse(string.Format(x.Date, "yyyy-MM-dd")) >= startDate &&
                                                         DateTime.Parse(string.Format(x.Date, "yyyy-MM-dd")) <= endDate).ToList();

            if (result is null)
            {
                return Array.Empty<CdiDay>();
            }

            return result;
        }


        /* The UrlBacenEndPoint (https://api.bcb.gov.br/dados/serie/bcdata.sgs.12/dados?formato=json) has a compressed return
         * I've tried using native HttpHandler with mode=Descompress.All but it hasn't worked yet. */
        private async Task<string> GetHistoricalSeriesResponse(string url)
        {
            using (var request = new HttpRequestMessage(HttpMethod.Get, new Uri(url)))
            {
                request.Headers.TryAddWithoutValidation("Accept", "text/html,application/xhtml+xml,application/xml");
                request.Headers.TryAddWithoutValidation("Accept-Encoding", "gzip, deflate, br");
                request.Headers.TryAddWithoutValidation("User-Agent", "Mozilla/5.0 (Windows NT 6.2; WOW64; rv:19.0) Gecko/20100101 Firefox/19.0");
                request.Headers.TryAddWithoutValidation("Accept-Charset", "utf-8");

                using (var response = await _httpClient.SendAsync(request).ConfigureAwait(false))
                {
                    response.EnsureSuccessStatusCode();
                    return await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                }
            }
        }
    }
}
