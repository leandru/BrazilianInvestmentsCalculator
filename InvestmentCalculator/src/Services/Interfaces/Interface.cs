using InvestmentCalculator.src.Models;

namespace InvestmentCalculator.src.Services.Interfaces
{
    public interface ICdiRepository
    {
        IEnumerable<CdiDay> GetHistoricalSeries( DateOnly startDate, DateOnly endDate );
        Task<bool> AddHistoricalSeries( IEnumerable<CdiDay> historicalSeries );
    }
}
