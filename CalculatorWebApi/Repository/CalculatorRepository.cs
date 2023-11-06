using CalculatorWebApi.Context;
using CalculatorWebApi.Domain;
using CalculatorWebApi.DTO;
using CalculatorWebApi.IRepository;
using Microsoft.EntityFrameworkCore;

namespace CalculatorWebApi.Repository
{
	public class CalculatorRepository : ICalculatorRepository
	{
		private readonly CalculatorDbContext _context;
        public CalculatorRepository(CalculatorDbContext context)
        {
            _context = context;
        }
        public async Task<bool> AddCalculationHistory(CalculatorDto cal, CancellationToken token)
		{
			if (cal is null)
			{
				return false;
			}

			var mapHistory = new Calculator()
			{
				operation = cal.operation,
				result = cal.result
			};

			await _context.AddAsync(mapHistory);

			return await _context.SaveChangesAsync() > 0;
		}

		public async Task DeleteCalculationHistory(int Id, CancellationToken token)
		{
			var history = await _context.calculations.FindAsync(Id);
			if (history is null)
			{
				return;
			}
			_context.calculations.Remove(history);
			await _context.SaveChangesAsync();
		}

		public async Task<List<CalculatorVM>> GetCalculationHistory()
		{
			try
			{
				return await _context.calculations.Select(cal =>
				new CalculatorVM()
				{
					Id = cal.Id,
					operation = cal.operation,
					result = cal.result
				}).ToListAsync();	
			}
			catch (Exception ex)
			{

				throw new Exception(ex.Message);
			}
		}

		public async Task<CalculatorVM> GetOneHistory(int Id, CancellationToken token)
		{
			var history = await _context.calculations.FindAsync(Id);

			return new CalculatorVM()
			{
				Id = history.Id,
				operation = history.operation,
				result = history.result
			};
		}
	}
}
