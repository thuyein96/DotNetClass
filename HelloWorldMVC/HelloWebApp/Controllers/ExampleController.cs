using Microsoft.AspNetCore.Mvc;

namespace HelloWebApp.Controllers
{
    public class ExampleController : Controller
    {

        public ViewResult Index()
        {
            return View();
        }

        // hosting://server/example/fullname?firstname=Mg&lastName=Mg
        public ViewResult FullName(string firstname, string lastname)
        {
            if (string.IsNullOrEmpty(firstname) || string.IsNullOrEmpty(lastname))
            {
                ViewBag.FullName = "Anonymous user!!";
            }
            else
            {
                ViewBag.FullName = $"Hi, I am {firstname} {lastname}";
            }
            return View();
        }

        [HttpGet]
        public IActionResult Sum(int n1, int n2)
        {
            ViewBag.Result=n1 + n2;
            return View();
        }

        // hosting://port/example/download >> 404
        [NonAction]
        [ActionName("download")]
        public FileResult DownloadFile()
        {
            string fileName = "Term Project.pdf";
            string filePath = Path.Combine("wwwroot/files/", fileName);
            byte[] contents = System.IO.File.ReadAllBytes(filePath);
            return File(contents, "text/pdf", fileName);
        }

        [HttpPost]
        public IActionResult Send(string name, string message)
        {
            ViewBag.Info=$"Hello, {name}. I send this message: {message}";
            return View();
        }

        

        
    }
}
