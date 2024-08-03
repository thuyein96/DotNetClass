using CloudHRMS.Models.ViewModels;
using CloudHRMS.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CloudHRMS.Controllers;

public class EmployeeController : Controller
{
    private readonly IEmployeeService _employeeService;

    public EmployeeController(IEmployeeService employeeService)
    {
        _employeeService = employeeService;
    }


    [Authorize(Roles = "HR")]
    public IActionResult Entry()
    {
        ViewBag.Positions = _employeeService.bindPositionData();
        ViewBag.Departmetns = _employeeService.bindDepartmentData();
        return View();
    }
    [Authorize(Roles = "HR")]
    [HttpPost]
    public IActionResult Entry(EmployeeViewModel ui)
    {
        try
        {
            var isAlreadyExist = _employeeService.IsAlreadyExist(ui);
            if (isAlreadyExist)
            {
                ViewData["Info"] = "This Position code or name is already exist in the system.";
                ViewData["Status"] = false;
                return View(ui);
            }
            _employeeService.Create(ui);
            ViewData["Info"] = "Successfully save the recrod to the system.";
            ViewData["Status"] = true;
        }
        catch (Exception e)
        {
            ViewData["Info"] = "Error occur when the record save to the system." + e.Message;
            ViewData["Status"] = false;
        }
        ViewBag.Positions = _employeeService.bindPositionData();
        ViewBag.Departments = _employeeService.bindDepartmentData();
        return View();
    }

    public IActionResult List() => View(_employeeService.GetAll());

    [Authorize(Roles = "HR")]
    public IActionResult Edit(string id)
    {
        EmployeeViewModel employeeView = _employeeService.GetById(id);
        _employeeService.bindDepartmentData();
        _employeeService.bindPositionData();
        return View(employeeView);
    }

    [HttpPost]
    public IActionResult Update(EmployeeViewModel employeeViewModel)
    {
        try
        {
            //Data Exchange from view Model to Entity
            //ViewModels to Data Models
            var isAlreadyExist = _employeeService.IsAlreadyExist(employeeViewModel);
            if (isAlreadyExist)
            {
                return View("Edit", employeeViewModel);
            }
            _employeeService.Update(employeeViewModel);
            TempData["Info"] = "Successfully update the record to the system.";
            TempData["Status"] = true;
        }
        catch (Exception e)
        {
            ViewData["Info"] = "Error occur when the record update to the system." + e.Message;
            ViewData["Status"] = false;
        }
        return RedirectToAction("List");
    }

    public IActionResult Delete(string id)
    {
        try
        {
            _employeeService.Delete(id);
            TempData["Info"] = "Delete Successfully";
        }
        catch (Exception e)
        {
            TempData["Info"] = "Error occur when delete the record." + e.Message;
        }
        return RedirectToAction("List");
    }
}
