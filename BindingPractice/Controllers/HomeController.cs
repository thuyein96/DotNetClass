using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BindingPractice.Models;

namespace BindingPractice.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }
    
    public IActionResult Register() => View();
    [HttpPost]
    public IActionResult Register(Employee employee)
    {
        ViewData["Info"] = $"Hello,{employee.Name} is registered at the country {employee.HomeAddress.Country}";
        return View();
    }

    public IActionResult RegisterAsList() => View();

    [HttpPost]
    public IActionResult RegisterAsList(IList<Employee> employees)
    {
        ViewData["Info"] = $"Total Register Count: {employees.Count}";
        
        return View();
    }
}
