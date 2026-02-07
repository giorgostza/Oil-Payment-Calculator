namespace Oil_Payment_Calculator.Models
{

    public enum ApartmentType
    {
        Floor = 1,        // Οροφος
        Shop = 2,         // Καταστημα-ισογειο
        Basement = 3     // Υπογειο
    }

    public class Apartment
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public ApartmentType Type { get; set; }


    }
}
