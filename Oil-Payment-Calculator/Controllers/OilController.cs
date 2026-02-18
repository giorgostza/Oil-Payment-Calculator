using Microsoft.AspNetCore.Mvc;
using Oil_Payment_Calculator.Data;
using Oil_Payment_Calculator.Models;
using Oil_Payment_Calculator.Services;

namespace Oil_Payment_Calculator.Controllers
{
    public class OilController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IOilCalculatorService _calculator;
        public OilController(ApplicationDbContext context, IOilCalculatorService calculator)
        {
            _context = context;
            _calculator = calculator;
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

            if (!ModelState.IsValid)
                return View(model);

            _calculator.Calculate(model);

            return View(model);
        }
    }
}

