using CloudHRMS.Models.ViewModels;
using CloudHRMS.Services;
using Microsoft.AspNetCore.Mvc;

namespace CloudHRMS.Controllers;

public class DailyAttendanceController : Controller
{
    private readonly IDailyAttendanceService _dailyAttendanceService;

    public DailyAttendanceController(IDailyAttendanceService dailyAttendanceService)
    {
        _dailyAttendanceService = dailyAttendanceService;
    }


    public IActionResult Entry()
    {
        ViewBag.Employees = _dailyAttendanceService.bindEmployeeData();
        ViewBag.Departments = _dailyAttendanceService.bindDepartmentData();
        return View();
    }


    [HttpPost]
    public IActionResult Entry(DailyAttendanceViewModel dailyAttendanceViewModel)
    {
        try
        {
            _dailyAttendanceService.Create(dailyAttendanceViewModel);
            ViewData["Info"] = "Successfully save the recrod to the system.";
            ViewData["Status"] = true;
        }
        catch (Exception e)
        {
            ViewData["Info"] = "Error occur when the record save to the system." + e.Message;
            ViewData["Status"] = false;
        }

        ViewBag.Employees = _dailyAttendanceService.bindEmployeeData();
        ViewBag.Departments = _dailyAttendanceService.bindDepartmentData();
        return View();
    }

    public IActionResult List() => View(_dailyAttendanceService.GetAll());


    public IActionResult Edit(string id)
    {
        DailyAttendanceViewModel dailyAttendanceView = _dailyAttendanceService.GetById(id);
        ViewBag.Employees = _dailyAttendanceService.bindEmployeeData();
        ViewBag.Departments = _dailyAttendanceService.bindDepartmentData();
        return View(dailyAttendanceView);
    }

    [HttpPost]
    public IActionResult Update(DailyAttendanceViewModel dailyAttendanceViewModel)
    {
        try
        {
            _dailyAttendanceService.Update(dailyAttendanceViewModel);
            ViewData["Info"] = "Successfully update the record to the system.";
            ViewData["Status"] = true;
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
            _dailyAttendanceService.Delete(id);
            TempData["Info"] = "Delete Successfully";
        }
        catch (Exception e)
        {
            TempData["Info"] = "Error occur when delete the record." + e.Message;
        }
        return RedirectToAction("List");
    }
}
