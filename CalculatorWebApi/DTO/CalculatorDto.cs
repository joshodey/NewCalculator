namespace CalculatorWebApi.DTO
{
	public record CalculatorDto
	{
        public string? operation { get; set; }
		public string? result { get; set; }
	}

	public record CalculatorVM : CalculatorDto
	{
		public int Id { get; set; }
	}
}
