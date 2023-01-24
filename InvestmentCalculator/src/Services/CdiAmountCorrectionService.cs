using InvestmentCalculator.src.Models;
using InvestmentCalculator.src.Services.Interfaces;
using System.Globalization;

namespace InvestmentCalculator.src.Services
{
    public sealed class CdiAmountCorrectionService //: ICdiAmountCorrectionService
    {
        public CdiAmountCorrectionService() { }

        public CdiAmountCorrectionResult CalculateCDICorrection(IEnumerable<CdiDay> cdiDays, double value, double cdiPercentage)
        {
            var totalIndexFee = Math.Round(CalculateAccumulatedDI(cdiDays, cdiPercentage), 8);
            var totalIndexFeePercentage = Math.Round(GetDIPercentage(totalIndexFee), 8);

            var correctedValue = Math.Round(value * totalIndexFee, 2);

            return new CdiAmountCorrectionResult
            {
                CorrectedAmount = correctedValue,
                CorrectionIndexFee = totalIndexFee,
                CorrectionIndexFeePercentage = totalIndexFeePercentage
            };
        }

        public double CalculateAccumulatedDI(IEnumerable<CdiDay> cdiDays, double cdiPercentage = 100)
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
            return 1 + (Double.Parse(cdiDay.Value, CultureInfo.InvariantCulture.NumberFormat)/100 * cdiPercentage / 100);
        }

        private double GetDIPercentage( double totalFee )
        {
            return (totalFee - 1) * 100;
        }

    }
}
