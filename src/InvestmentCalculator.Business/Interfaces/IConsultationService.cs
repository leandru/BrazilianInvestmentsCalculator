using InvestmentCalculator.Business.Models;

namespace InvestmentCalculator.Business.Interfaces
{
    public interface IConsultationService
    {
        Task<IEnumerable<CdiDay>> GetCDIHistoricalSeries(DateTime startDate, DateTime endDate);
    }
}
