using InvestmentCalculator.Business.Services;
using InvestmentCalculator.Business.Models;
using Microsoft.AspNetCore.Mvc;
using FluentValidation;
using FluentValidation.Results;
using InvestmentCalculator.API.Configuration;
using InvestmentCalculator.API.ViewModels;
using InvestmentCalculator.Business.Interfaces;

namespace InvestmentCalculator.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InvestmentCalculatorController : ControllerBase
    {
        private readonly ILogger<InvestmentCalculatorController> _logger;

        private readonly IConsultationService _cdiConsultationService;
        private readonly ICalculationService _cdiAmountCorrectionService;
        private IValidator<LciInputParameters> _validator;

        public InvestmentCalculatorController(ILogger<InvestmentCalculatorController> logger,
               ICalculationService cdiAmountCorrectionService,
               IConsultationService cdiConsultationService,
               IValidator<LciInputParameters> validator)
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
            var cdiInputParameters = new LciInputParameters ( startDate, endDate, investmentAmount, cdiPercentage );
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

            var historicalSeriesRange = await _cdiConsultationService.GetCDIHistoricalSeries(startDate, endDate);
            var result = await _cdiAmountCorrectionService.CalculateCDICorrection(historicalSeriesRange, investmentAmount, cdiPercentage);

            return Ok(new
            {
                success = true,
                data = result
            });
        }


        [HttpGet("CalculateCompoundInterest")]
        public async Task<double> CalculateCompoundInterest(double principal, double annualRate, int time)
        {
            return await _cdiAmountCorrectionService.CalculateCompoundInterest( principal, annualRate, time);
        }

        private async Task<(bool HasErrors, List<MessageResult>? Errors)> ValidateParameters(LciInputParameters cdiInputParameters)
        {
            ValidationResult result = await _validator.ValidateAsync(cdiInputParameters);

            return (result.Errors.Any(),result.GetErrors());
        }

    }
}