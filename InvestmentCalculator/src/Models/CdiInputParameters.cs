namespace InvestmentCalculator.src.Models
{
    public class CdiInputParameters
    {
        public DateOnly StartDate { get; set; }

        public DateOnly FinalDate { get; set; }

        public double InvestmentAmount { get; set; }

        public double CdiPercentage { get; set; }
    }
}