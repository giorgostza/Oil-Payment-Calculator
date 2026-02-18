namespace Oil_Payment_Calculator.Models
{
    public class ApartmentCalculationVM
    {

        public int ApartmentId { get; set; }
        public string ApartmentName { get; set; }
        public ApartmentType ApartmentType { get; set; }

        public int PreviousReading { get; set; }
        public int CurrentReading { get; set; }

        public decimal Difference { get; set; }

        public decimal Coefficient { get; set; }
        public decimal Product { get; set; }

        public decimal Share { get; set; }
        public decimal AmountToPay { get; set; }





    }
}
