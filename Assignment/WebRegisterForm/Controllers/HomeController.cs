using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebRegisterForm.Models;

namespace WebRegisterForm.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        var person = new PersonViewModel();
        return View(person);
    }

    public IActionResult Register(PersonViewModel person)
    {
        if (person.Password.Equals(person.Password2))
        {
            person.SuccessMessage = $"You are successfully register with {person.Email} email address";
            return View(person);
        }
        return View();
    }

    
}
