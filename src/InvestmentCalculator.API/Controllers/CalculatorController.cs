using InvestmentCalculator.API.Services;
using InvestmentCalculator.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace InvestmentCalculator.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InvestmentCalculatorController : ControllerBase
    {
        private readonly ILogger<InvestmentCalculatorController> _logger;

        private readonly CdiConsultationService _cdiConsultationService;
        private readonly CdiAmountCorrectionService _cdiAmountCorrectionService;

        public InvestmentCalculatorController(ILogger<InvestmentCalculatorController> logger, 
               CdiAmountCorrectionService cdiAmountCorrectionService, 
               CdiConsultationService cdiConsultationService)
        {
            _logger = logger;
            _cdiConsultationService = cdiConsultationService;
            _cdiAmountCorrectionService = cdiAmountCorrectionService;
        }

        [HttpGet("CalculateCDICorrection")]
        public async Task<CdiAmountCorrectionResult> CalculateCDICorrection(DateTime startDate,
                                                                            DateTime endDate,
                                                                            double investmentAmount, 
                                                                            double cdiPercentage)
        {
            var historicalSeriesRange = await _cdiConsultationService.GetHistoricalSeries(startDate, endDate);
            var result = _cdiAmountCorrectionService.CalculateCDICorrection(historicalSeriesRange, investmentAmount, cdiPercentage);

            return result;
        }

        public async Task<IEnumerable<CdiDay>> GetHistoricalSeries()
        {
            return await _cdiConsultationService.GetHistoricalSeries();
        }
    }
}