using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TaxCalculator.ViewModels;

namespace TaxCalculator.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var tax = new TaxViewModel();
            return View(tax);
        }

        
    }
}
