using Oil_Payment_Calculator.Models;

namespace Oil_Payment_Calculator.Services
{
    public interface IOilCalculatorService
    {

        void Calculate(OilCalculationVM model);

    }
}
