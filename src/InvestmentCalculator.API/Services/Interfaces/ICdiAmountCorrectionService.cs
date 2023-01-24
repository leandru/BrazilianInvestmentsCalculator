using InvestmentCalculator.API.Models;

namespace InvestmentCalculator.API.Services.Interfaces
{
    public interface ICdiAmountCorrectionService
    {
        CdiAmountCorrectionResult CalculateCDICorrection(CdiInputParameters cdiParams);
    }
}
