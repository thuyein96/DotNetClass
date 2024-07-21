using CloudHRMS.DAO;
using CloudHRMS.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CloudHRMS.Controllers
{
    public class DayEndProcessController : Controller
    {
        private readonly CloudHRMSApplicationDbContext _cloudHRMSApplicationDbContext;

        public DayEndProcessController(CloudHRMSApplicationDbContext cloudHRMSApplicationDbContext)
        {
            _cloudHRMSApplicationDbContext = cloudHRMSApplicationDbContext;
        }

        private void bindDepartmentData()
        {
            IList<DepartmentViewModel> departments = _cloudHRMSApplicationDbContext.Departments.Where(w => !w.IsInActive).Select(s =>
            new DepartmentViewModel
            {
                Id = s.Id,
                Code = s.Code + "/" + s.Name
            }).ToList();
            ViewBag.Departments = departments;
        }
        private void bindEmployeeData()
        {
            IList<EmployeeViewModel> employees = _cloudHRMSApplicationDbContext.Employees.Where(w => !w.IsInActive).Select(s =>
            new EmployeeViewModel
            {
                Id = s.Id,
                Code = s.Code + "/" + s.Name
            }).ToList();
            ViewBag.Employees = employees;
        }
        private void bindShiftData()
        {
            IList<ShiftViewModel> shifts = _cloudHRMSApplicationDbContext.Shifts.Where(w => !w.IsInActive).Select(s =>
            new ShiftViewModel
            {
                Id = s.Id,
                Name = s.Name
            }).ToList();
            ViewBag.Shifts = shifts;
        }
        public IActionResult DayEndProcess()
        {
            bindDepartmentData();
            bindEmployeeData();
            bindShiftData();
            return View();
        }
    }
}
