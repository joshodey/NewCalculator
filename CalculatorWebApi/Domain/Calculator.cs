using System.ComponentModel.DataAnnotations;

namespace CalculatorWebApi.Domain
{
	public class Calculator
	{
		[Key]
		public int Id { get; set; }
        public string operation { get; set; }
		public string result { get; set; }
    }
}
