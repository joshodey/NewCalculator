namespace NewCalculator.ViewModel
{
    public record CalculatorVM
    {
        public string? operation { get; set; }
        public string? result { get; set; }
    }

    public record CalculatorDto : CalculatorVM
    {
        public int Id { get; set; }
    }
}
