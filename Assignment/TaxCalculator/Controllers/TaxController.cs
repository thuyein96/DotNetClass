using Microsoft.AspNetCore.Mvc;
using TaxCalculator.ViewModels;

namespace TaxCalculator.Controllers
{
    public class TaxController : Controller
    {

        public IActionResult Index()
        {
            var taxinfo = new TaxViewModel();
            return View(taxinfo);
        }

        [HttpPost]
        public IActionResult Index(TaxViewModel taxinfo)
        {
            var incomeBeforeTax = taxinfo.Income;
            if (taxinfo.Income >= 500000)
            {
                if (taxinfo.Father == "true")
                {
                    incomeBeforeTax = incomeBeforeTax - 50000;
                }
                if (taxinfo.Mother == "true")
                {
                    incomeBeforeTax = incomeBeforeTax - 50000;
                }
                if (taxinfo.IsMarried)
                {
                    var taxByChild = taxinfo.Children * 30000;
                    incomeBeforeTax = incomeBeforeTax - taxByChild;
                }

                var taxAmount = incomeBeforeTax * 0.02m;
                taxinfo.AfterTax = incomeBeforeTax - taxAmount;
            }
            else
            {
                taxinfo.AfterTax = incomeBeforeTax;
            }
            return View(taxinfo);
        }
    }
}
