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
        public IActionResult ConverterV2(string selectedCurrency, string selectedCurrency2, float amount)
        {
            if (amount<0 || "".Equals(selectedCurrency) || "".Equals(selectedCurrency2))
            {
                return View(); 
            }

            ViewData["selectedCurrency"]= selectedCurrency;
            ViewData["selectedCurrency2"] = selectedCurrency2;
            ViewData["InputtedAmount"]=amount;
            if (selectedCurrency == "usd")
            {
                switch (selectedCurrency2)
                {
                    case "usd": ViewData["result"] = amount; break;
                    case "sdg": ViewData["result"] = amount * 1.36; break;
                    case "baht": ViewData["result"] = amount * 37; break;
                    default: ViewData["result"] = "Nothing"; break;
                }
            }
            if(selectedCurrency == "sdg")
            {
                switch (selectedCurrency2)
                {
                    case "usd": ViewData["result"] = amount * 0.74; break;
                    case "sdg": ViewData["result"] = amount; break;
                    case "baht": ViewData["result"] = amount * 27; break;
                    default: ViewData["result"] = "Nothing"; break;
                }
            }
            if (selectedCurrency == "baht")
            {
                switch (selectedCurrency2)
                {
                    case "usd": ViewData["result"] = amount * 0.027; break;
                    case "sdg": ViewData["result"] = amount / 27.09; break;
                    case "baht": ViewData["result"] = amount * 0.037; break;
                    default: ViewData["result"] = "Nothing"; break;
                }
            }

            return View();
        }
    }
}