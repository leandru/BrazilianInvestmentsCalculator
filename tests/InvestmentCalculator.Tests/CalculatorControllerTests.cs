using InvestmentCalculator.Business.Models;
using InvestmentCalculator.Business.Services;

namespace InvestmentCalculator.Tests
{
    public class CalculatorControllerTests
    {
        [Fact]
        public void TestCalculateLCI_ShouldReturnCorrectResult()
        {

           var calculationService = new CalculationService();
           var result = calculationService.CalculateCDICorrection(GetCdiDaysList(), 1000, 120);

           Assert.NotNull(result);
           Assert.IsType<CdiAmountCorrectionResult>(result);

           Assert.Equal(1001.32, Math.Round(result.CorrectedAmount,2));
        }

        [Fact]
        public void TestCalculateLCI_ShouldReturnError()
        {

            var calculationService = new CalculationService();
            var result = calculationService.CalculateCDICorrection(GetCdiDaysList(), 1000, 100);

            Assert.NotNull(result);
            Assert.IsType<CdiAmountCorrectionResult>(result);

            Assert.NotEqual(0, result.CorrectedAmount);
        }


        private IEnumerable<CdiDay> GetCdiDaysList()
        {
            var list = new List<CdiDay>();
            list.Add(new CdiDay{
                Date = "01/02/2022",
                Value = "0.034749"
            });

            list.Add(new CdiDay
            {
                Date = "02/02/2022",
                Value = "0.034749"
            });

            list.Add(new CdiDay
            {
                Date = "03/02/2022",
                Value = "0.040168"
            });

            return list;
        }
    }
}