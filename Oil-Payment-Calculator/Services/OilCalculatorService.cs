using Oil_Payment_Calculator.Models;

namespace Oil_Payment_Calculator.Services
{
    public class OilCalculatorService : IOilCalculatorService
    {
        public void Calculate(OilCalculationVM model)
        {
            CalculateProducts(model);
            CalculateShares(model);
            CalculateFinalAmounts(model);
        }


        private void CalculateProducts(OilCalculationVM model)
        {
            foreach (var apt in model.Apartments)
            {
                apt.Difference = CalculateDifference(apt);
                apt.Product = apt.Difference * GetCoefficient(apt);
            }

            model.TotalSum = model.Apartments.Sum(a => a.Product);
        }

        private void CalculateShares(OilCalculationVM model)
        {
            foreach (var apt in model.Apartments)
            {
                apt.Share = model.TotalSum == 0 ? 0 : apt.Product / model.TotalSum;

            }
        }

        private void CalculateFinalAmounts(OilCalculationVM model)
        {
            foreach (var apt in model.Apartments)
            {
                apt.AmountToPay = apt.Share * model.OilPricePerLiter * model.TotalLiters;
            }

            model.TotalSumToPay = model.Apartments.Sum(a => a.AmountToPay);
        }


        private decimal CalculateDifference(ApartmentCalculationVM apt)
        {
            return Math.Max(0, apt.CurrentReading - apt.PreviousReading);
        }

        private decimal GetCoefficient(ApartmentCalculationVM apt)
        {
            // Θα το αλλάξουμε στο επόμενο βήμα
            return 0;
        }

    }
}
