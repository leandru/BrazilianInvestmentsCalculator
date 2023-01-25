using InvestmentCalculator.Business.Models;

namespace InvestmentCalculator.Business.Interfaces
{
    public interface ICalculationService    
    {
        Task<CdiAmountCorrectionResult> CalculateCDICorrection(IEnumerable<CdiDay> cdiDays, double value, double cdiPercentage);
        Task<double> CalculateCompoundInterest(double principal, double annualRate, int months);
    }
}
