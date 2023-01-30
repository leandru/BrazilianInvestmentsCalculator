using InvestmentCalculator.Business.Models;
using InvestmentCalculator.Business.Services;
using InvestmentCalculator.Tests.Utils;

namespace InvestmentCalculator.Tests.Units
{
    public class CalculationServiceTests
    {
        [Fact]
        public void CalculateLCI_ShouldReturn_CorrectResult()
        {

            var calculationService = new CalculationService();
            var result = calculationService.CalculateCDICorrection(MockedValues.GetCdiDaysList(), 1000, 120);

            Assert.NotNull(result);
            Assert.IsType<CdiAmountCorrectionResult>(result);

            Assert.Equal(1001.32, Math.Round(result.CorrectedAmount, 2));
        }

        [Fact]
        public void CalculateLCI_ShouldNotReturn_NullOrZero()
        {

            var calculationService = new CalculationService();
            var result = calculationService.CalculateCDICorrection(MockedValues.GetCdiDaysList(), 1000, 100);

            Assert.NotNull(result);
            Assert.IsType<CdiAmountCorrectionResult>(result);

            Assert.NotEqual(0, result.CorrectedAmount);
        }

    }
}