namespace Oil_Payment_Calculator.Models
{
    public class OilCalculationVM
    {
        public decimal OilPricePerLiter { get; set; }

        public List<ApartmentCalculationVM> Apartments { get; set; } = new();

        public decimal TotalSum { get; set; }

      

    }
}
