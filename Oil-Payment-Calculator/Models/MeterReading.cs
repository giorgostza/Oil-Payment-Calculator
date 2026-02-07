namespace Oil_Payment_Calculator.Models
{
    public class MeterReading
    {

        public int Id { get; set; }

        public int ApartmentId { get; set; }

        public Apartment Apartment { get; set; }

        public int PreviousReading { get; set; }

        public int CurrentReading { get; set; }


        public int GetDifference()
        {

            return CurrentReading - PreviousReading;
        }


    }
}
