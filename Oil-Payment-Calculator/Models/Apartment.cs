namespace Oil_Payment_Calculator.Models
{

    public enum ApartmentType
    {
        Floor,        // Οροφος
        Shop,         // Καταστημα-ισογειο
        Basement      // Υπογειο
    }

    public class Apartment
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public ApartmentType Type { get; set; }


    }
}
