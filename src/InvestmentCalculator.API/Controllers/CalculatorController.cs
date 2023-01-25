using InvestmentCalculator.API.Services;
using InvestmentCalculator.API.Models;
using Microsoft.AspNetCore.Mvc;
using FluentValidation;
using FluentValidation.Results;
using InvestmentCalculator.API.Configuration;

namespace InvestmentCalculator.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InvestmentCalculatorController : ControllerBase
    {
        private readonly ILogger<InvestmentCalculatorController> _logger;

        private readonly CdiConsultationService _cdiConsultationService;
        private readonly CdiAmountCorrectionService _cdiAmountCorrectionService;
        private IValidator<CdiInputParameters> _validator;

        public InvestmentCalculatorController(ILogger<InvestmentCalculatorController> logger,
               CdiAmountCorrectionService cdiAmountCorrectionService,
               CdiConsultationService cdiConsultationService,
               IValidator<CdiInputParameters> validator)
        {
            _logger = logger;
            _cdiConsultationService = cdiConsultationService;
            _cdiAmountCorrectionService = cdiAmountCorrectionService;
            _validator = validator;
        }

        [HttpGet("CalculateLCI")]
        public async Task<IActionResult> CalculateLCI(DateTime startDate,
                                                                DateTime endDate,
                                                                double investmentAmount,
                                                                double cdiPercentage)
        {
            #region Validations
            var cdiInputParameters = new CdiInputParameters ( startDate, endDate, investmentAmount, cdiPercentage );
            var resultValidation = await ValidateParameters(cdiInputParameters);

            if(resultValidation.HasErrors)
            {
                return BadRequest(new
                {
                    success = false,
                    data = resultValidation.Errors
                });
            }
            #endregion

            var historicalSeriesRange = await _cdiConsultationService.GetHistoricalSeries(startDate, endDate);
            var result = _cdiAmountCorrectionService.CalculateCDICorrection(historicalSeriesRange, investmentAmount, cdiPercentage);

            return Ok(new
            {
                success = true,
                data = result
            });
        }

        [HttpGet("GetHistoricalSeries")]
        public async Task<IEnumerable<CdiDay>> GetHistoricalSeries()
        {
            return await _cdiConsultationService.GetHistoricalSeries();
        }

        private async Task<(bool HasErrors, List<MessageResult>? Errors)> ValidateParameters(CdiInputParameters cdiInputParameters)
        {
            ValidationResult result = await _validator.ValidateAsync(cdiInputParameters);

            return (result.Errors.Any(),result.GetErrors());
        }

        private bool IsGreaterThanToday(DateTime date)
        {
            return date > DateTime.Today;
        }

    }
}