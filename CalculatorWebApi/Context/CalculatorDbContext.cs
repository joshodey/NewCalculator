using CalculatorWebApi.Domain;
using Microsoft.EntityFrameworkCore;

namespace CalculatorWebApi.Context
{
	public class CalculatorDbContext: DbContext 
	{
        public CalculatorDbContext(DbContextOptions<CalculatorDbContext> options) : base(options)
        {
            
        }

        public DbSet<Calculator> calculations { get; set; }
    }
}
