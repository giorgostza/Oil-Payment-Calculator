using Microsoft.AspNetCore.Mvc;
using Oil_Payment_Calculator.Data;
using Oil_Payment_Calculator.Models;

namespace Oil_Payment_Calculator.Controllers
{
    public class OilController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OilController(ApplicationDbContext context)
        {
            _context = context;
        }

        
        public IActionResult Index()
        {

            var apartments = _context.Apartments.ToList();


            var vm = new OilCalculationVM
            {
                Apartments = apartments.Select(a => new ApartmentCalculationVM
                {
                    ApartmentId = a.Id,
                    ApartmentName = a.Name,
                    ApartmentType = a.Type
                }).ToList()
            };


            return View(vm);
        }


        [HttpPost]
        public IActionResult Index(OilCalculationVM model)
        {
            // ΒΗΜΑ 1: Διαφορές + Συντελεστές
            foreach (var apt in model.Apartments)
            {
                apt.Difference = apt.CurrentReading - apt.PreviousReading;

                apt.Coefficient = apt.ApartmentType switch
                {
                    ApartmentType.Floor => 17500m,
                    ApartmentType.Shop => 16640m,
                    ApartmentType.Basement => 6000m,
                    _ => 0
                };

                apt.Product = apt.Difference * apt.Coefficient;
            }

            // ΒΗΜΑ 2: ΣΥΝΟΛΟ 1
            model.TotalSum = model.Apartments.Sum(a => a.Product);

            
            // ΒΗΜΑ 3: Μερίδιο & Πληρωμή
            foreach (var apt in model.Apartments)
            {
                apt.Share = model.TotalSum == 0 ? 0 : apt.Product / model.TotalSum;
                apt.AmountToPay = apt.Share * model.OilPricePerLiter * model.TotalLiters;
                 
            }

            model.TotalSumToPay = model.Apartments.Sum(a => a.AmountToPay);

            return View(model);
        }
    }
}

