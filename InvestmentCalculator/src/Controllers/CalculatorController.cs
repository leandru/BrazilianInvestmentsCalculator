using InvestmentCalculator.API.src.Services;
using InvestmentCalculator.src.Models;
using InvestmentCalculator.src.Services;
using InvestmentCalculator.src.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace InvestmentCalculator.src.Controllers
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
    }
}