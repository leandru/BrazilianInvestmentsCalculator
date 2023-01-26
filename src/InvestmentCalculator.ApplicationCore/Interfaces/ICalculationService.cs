using InvestmentCalculator.Business.Models;

namespace InvestmentCalculator.Business.Interfaces
{
    public interface ICalculationService    
    {
        CdiAmountCorrectionResult CalculateCDICorrection(IEnumerable<CdiDay> cdiDays, double value, double cdiPercentage);
        double CalculateCompoundInterest(double principal, double annualRate, int months);
    }
}
