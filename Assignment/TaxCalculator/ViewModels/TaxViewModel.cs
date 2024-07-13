namespace TaxCalculator.ViewModels
{
    public class TaxViewModel
    {
        public decimal Income { get; set; }
        public string Father { get; set; }
        public string Mother { get; set; }
        public bool IsMarried { get; set; }
        public int Children { get; set; }
        public decimal Tax { get; set; }
    }
}
