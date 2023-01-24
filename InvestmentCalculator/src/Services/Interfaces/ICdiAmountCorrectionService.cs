using InvestmentCalculator.src.Models;

namespace InvestmentCalculator.src.Services.Interfaces
{
    public interface ICdiAmountCorrectionService
    {
        CdiAmountCorrectionResult CalculateCDICorrection(CdiInputParameters cdiParams);
    }
}
