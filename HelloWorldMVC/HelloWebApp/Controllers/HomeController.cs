using Microsoft.AspNetCore.Mvc;

namespace HelloWebApp.Controllers
{
    public class HomeController : Controller
    {
        //aciton method
        //localhost:5145/home/Hi
        public string Hi()
        {
            return "Hello, I come from home controller";
        }

        //localhost:5145/home/GetNow
        public string GetNow()
        {
            return DateTime.Now.ToString();
        }

        // 2 types of calling Index View
        // Type 1
        public ViewResult GoToIndex()
        {
            return View("Index");
        }
        // Type 2 (Recommended)
        public ViewResult Index()
        {
            return View();
        }

        public ViewResult Welcome()
        {
            ViewData["Day"] = "Sunday"; 
            return View();
        }
    }
}