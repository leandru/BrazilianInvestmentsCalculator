using InvestmentCalculator.src.Models;
using Microsoft.EntityFrameworkCore;

namespace InvestmentCalculator.API.src.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
           : base(options) { }

        public DbSet<CdiDay> Produtos { get; set; }
    }
}
