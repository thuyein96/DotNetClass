using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WorkOut.Controllers
{
    public class CurrencyConverterController : Controller
    {
        private readonly ILogger<CurrencyConverterController> _logger;

        public CurrencyConverterController(ILogger<CurrencyConverterController> logger)
        {
            _logger = logger;
        }

        public IActionResult ConverterV1 ()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ConverterV1(decimal amount, string selectedCurrency)
        {
            switch (selectedCurrency)
            {
                case "usd":ViewData["result"] = amount * 3000; break;
                case "sdg":ViewData["result"] = amount * 2500; break;
                case "baht":ViewData["result"] = amount * 120; break;
                default:ViewData["result"] = "Nothing"; break;
            }
            return View();
        }

        public IActionResult ConverterV2() => View(); //lambda style

        [HttpPost]
        public IActionResult ConverterV2(decimal amount, string selectedCurrency)
        {
            if (amount<0 || "".Equals(selectedCurrency))
            {
                return View(); 
            }

            ViewData["selectedCurrency"]=selectedCurrency;
            ViewData["InputtedAmount"]=amount;
            switch (selectedCurrency)
            {
                case "usd":ViewData["result"] = amount * 3000; break;
                case "sdg":ViewData["result"] = amount * 2500; break;
                case "baht":ViewData["result"] = amount * 120; break;
                default:ViewData["result"] = "Nothing"; break;
            }
            return View();
        }
    }
}