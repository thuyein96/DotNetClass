using Microsoft.AspNetCore.Mvc;

namespace CloudHRMS.Controllers
{
    public class PositionController : Controller
    {
        public IActionResult Entry()
        {
            return View();
        }
    }
}
