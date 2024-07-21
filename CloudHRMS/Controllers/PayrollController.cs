using CloudHRMS.DAO;
using CloudHRMS.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CloudHRMS.Controllers
{
    public class PayrollController : Controller
    {
        private readonly CloudHRMSApplicationDbContext _cloudHRMSApplicationDbContext;

        public PayrollController(CloudHRMSApplicationDbContext cloudHRMSApplicationDbContext)
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
        public IActionResult PayrollProcess()
        {
            bindEmployeeData();
            bindDepartmentData();
            return View();
        }

        public IActionResult PayrollReport()
        {
            return View();
        }
    }
}
