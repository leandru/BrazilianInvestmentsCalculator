using InvestmentCalculator.Business.Models;
using InvestmentCalculator.Business.Services;
using InvestmentCalculator.Tests.Mocks;

namespace InvestmentCalculator.Tests.Units
{
    public class CalculationServiceTests
    {
        [Theory]
        [ClassData(typeof(CalculatorServiceTestData))]
        public void CalculateLCI_ShouldReturn_CorrectResult(IEnumerable<CdiDay> cdiDays, 
                                                            double amount, double cdiPercentage,
                                                            double expectedValue)
        {

            var calculationService = new CalculationService();
            var result = calculationService.CalculateCDICorrection(cdiDays, amount, cdiPercentage);

            Assert.NotNull(result);
            Assert.IsType<AmountCorrectionResult>(result);
            Assert.NotEqual(0, result.CorrectedAmount);

            Assert.Equal(expectedValue, Math.Round(result.CorrectedAmount, 2));
        }

    }
}