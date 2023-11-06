using CalculatorWebApi.DTO;

namespace CalculatorWebApi.IRepository
{
	public interface ICalculatorRepository
	{
		Task<List<CalculatorVM>> GetCalculationHistory();

		Task<bool> AddCalculationHistory(CalculatorDto cal, CancellationToken token);
		Task DeleteCalculationHistory(int Id, CancellationToken token);

		Task<CalculatorVM> GetOneHistory(int Id, CancellationToken token);

	}
}
