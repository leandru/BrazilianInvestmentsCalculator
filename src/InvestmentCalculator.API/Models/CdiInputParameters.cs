namespace InvestmentCalculator.API.Models
{
    public class CdiInputParameters
    {
        public CdiInputParameters(DateTime startDate, DateTime endDate, double investmentAmount, double cdiPercentage)
        {
            StartDate = startDate;
            EndDate = endDate;
            InvestmentAmount = investmentAmount;
            CdiPercentage = cdiPercentage;
        }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public double InvestmentAmount { get; set; }

        public double CdiPercentage { get; set; }
    }
}