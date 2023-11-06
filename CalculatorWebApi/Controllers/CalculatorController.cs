using CalculatorWebApi.DTO;
using CalculatorWebApi.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CalculatorWebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CalculatorController : ControllerBase
	{
        private readonly ICalculatorRepository _calculator;
        public CalculatorController(ICalculatorRepository calculator)
        {
            _calculator = calculator;
        }

        [HttpGet]
        public async Task<IActionResult> GetHistor() 
        {
            try
            {
                return Ok(await _calculator.GetCalculationHistory());
            }
            catch (Exception ex)
            {
                throw new Exception("There is an error when Adding, check the log report");
            }
        }

        [HttpGet("history")]
        public async Task<IActionResult> GetSingleHistory(int Id, CancellationToken token)
        {
            try
            {
                return Ok(await _calculator.GetOneHistory(Id, token));
            }
            catch (Exception ex)
            {
                throw new Exception("There was an error getting this history, check log");
            }
        }

        [HttpPost("history")]
        public async Task<IActionResult> CreateHistory(CalculatorDto cal, CancellationToken token)
        {
            try
            {
                var result = await _calculator.AddCalculationHistory(cal, token);

                return result ? Ok(cal) : BadRequest();
            }
            catch (Exception ex)
            {

                throw new Exception("Unable to add this History");
            }
        }

        [HttpDelete("history")]
        public async Task<IActionResult> DeleteHistory(int Id, CancellationToken token)
        {
            try
            {
                var data = _calculator.GetOneHistory(Id, token);

                if (data is null)
                {
                    return BadRequest();
                }

                await _calculator.DeleteCalculationHistory(Id, token);

                return Ok("Success");
            }
            catch (Exception ex)
            {

                throw new Exception("Couldn't Delete, check log");
            }
        }
    }
}
