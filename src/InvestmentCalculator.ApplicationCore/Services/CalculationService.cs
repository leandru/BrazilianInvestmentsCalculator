using InvestmentCalculator.Business.Interfaces;
using InvestmentCalculator.Business.Models;
using System.Globalization;

namespace InvestmentCalculator.Business.Services
{
    public sealed class CalculationService: ICalculationService
    {
        public AmountCorrectionResult CalculateCDICorrection(IEnumerable<CdiDay> cdiDays, double value, double cdiPercentage)
        {
            var totalIndexFee = Math.Round(CalculateAccumulatedDI(cdiDays, cdiPercentage), 8);
            var totalIndexFeePercentage = Math.Round(GetDIPercentage(totalIndexFee), 8);

            var correctedValue = Math.Round(value * totalIndexFee, 2);

            return new AmountCorrectionResult
            {
                CorrectedAmount = correctedValue,
                CorrectionIndexFee = totalIndexFee,
                CorrectionIndexFeePercentage = totalIndexFeePercentage
            };
        }

        public double CalculateCompoundInterest(double principal, double annualRate, int months)
        {
            var annualCompound = 1;
            var monthFracion = (double)months / 12;
            annualRate /= 100;
            double amount = principal * Math.Pow((1 + annualRate / annualCompound),
                                         (annualCompound * monthFracion));
            return Math.Round(amount, 2);
        }

        private double CalculateAccumulatedDI(IEnumerable<CdiDay> cdiDays, double cdiPercentage = 100)
        {
            double totalFee = 1;
            foreach (var cdiDay in cdiDays)
            {
                totalFee *= CalculateAccumulatedDI(cdiDay, cdiPercentage);
            }

            return totalFee;
        }
        private double CalculateAccumulatedDI( CdiDay cdiDay, double cdiPercentage = 100 )
        {

            return 1 + (Double.Parse(cdiDay?.Value ?? "0", CultureInfo.InvariantCulture.NumberFormat)/100 * cdiPercentage / 100);
        }

        private double GetDIPercentage( double totalFee )
        {
            return (totalFee - 1) * 100;
        }

    }
}
