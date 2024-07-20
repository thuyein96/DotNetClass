using CloudHRMS.DAO;
using CloudHRMS.Models.Entities;
using CloudHRMS.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CloudHRMS.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly CloudHRMSApplicationDbContext _dbContext;
        public EmployeeController(CloudHRMSApplicationDbContext dbContext)
        {
            _dbContext = dbContext;   
        }

     
        public IActionResult Entry()
        {
            bindPositionData();
            bindDepartmentData();
            return View();
        }

        private void bindDepartmentData()
        {
            IList<DepartmentViewModel> departments = _dbContext.Departments.Where(w => !w.IsInActive).Select(s =>
            new DepartmentViewModel
            {
                Id = s.Id,
                Code = s.Code + "/" + s.Name
            }).ToList();
            ViewBag.Departments = departments;
        }

        private void bindPositionData()
        {
            IList<PositionViewModel> positions = _dbContext.Positions.Where(w => !w.IsInActive).Select(s =>
             new PositionViewModel
             {
                 Id = s.Id,
                 Code = s.Code + "/" + s.Name
             }).ToList();
            ViewBag.Positions = positions;
            
        }

        [HttpPost]
        public IActionResult Entry(EmployeeViewModel employeeViewModel)
        {
            try
            {
                EmployeeEntity employeeEntity = new EmployeeEntity()
                {
                    Id = Guid.NewGuid().ToString(),
                    Code = employeeViewModel.Code,
                    Name = employeeViewModel.Name,
                    Email = employeeViewModel.Email,
                    Gender = employeeViewModel.Gender,
                    DOB = employeeViewModel.DOB,
                    DOE = employeeViewModel.DOE,
                    DOR = employeeViewModel.DOR,
                    Address = employeeViewModel.Address,
                    BasicSalary = employeeViewModel.BasicSalary,
                    Phone = employeeViewModel.Phone,
                    PositionId = employeeViewModel.PositionId,
                    DepartmentId = employeeViewModel.DepartmentId,
                    CreatedAt = DateTime.Now
                };
                _dbContext.Employees.Add(employeeEntity);
                _dbContext.SaveChanges();
                ViewData["Info"] = "Successfully save the record to the system.";
                ViewData["Status"] = true;
            }
            catch (Exception e)
            {
                ViewData["Info"] = "Error occur when the record save to the system." + e.Message;
                ViewData["Status"] = false;
            }
            bindPositionData();
            bindDepartmentData();
            return View();
        }

        public IActionResult List()
        {
            IList<EmployeeViewModel> employees = (from e in _dbContext.Employees
                                                  join d in _dbContext.Departments
                                                  on e.DepartmentId equals d.Id
                                                  join p in _dbContext.Positions
                                                  on e.PositionId equals p.Id
                                                  where !e.IsInActive && !d.IsInActive && !p.IsInActive
                                                  select new EmployeeViewModel
                                                  {
                                                      Id = e.Id,
                                                      Code = e.Code,
                                                      Name = e.Name,
                                                      Email = e.Email,
                                                      Gender = e.Gender,
                                                      DOB = e.DOB,
                                                      DOE = e.DOE,
                                                      DOR = e.DOR,
                                                      Address = e.Address,
                                                      BasicSalary = e.BasicSalary,
                                                      Phone = e.Phone,
                                                      DepartmentInfo = d.Code + "/" + d.Name,
                                                      PositionInfo = d.Code + "/" + d.Name
                                                  }).ToList();
            
            return View(employees);
        }

        public IActionResult Edit(string id)
        {
            EmployeeViewModel employeeView = _dbContext.Employees.Where(w => w.Id == id && !w.IsInActive).Select(s => new EmployeeViewModel
            {
                Id = s.Id,
                Code = s.Code,
                Name = s.Name,
                Email = s.Email,
                Gender = s.Gender,
                DOB = s.DOB,
                DOE = s.DOE,
                DOR = s.DOR,
                Address = s.Address,
                BasicSalary = s.BasicSalary,
                Phone = s.Phone,
                DepartmentId = s.DepartmentId,
                PositionId = s.PositionId,
                CreatedOn = s.CreatedAt,
                UpdatedOn = s.ModifiedAt
            }).FirstOrDefault();
            bindDepartmentData();
            bindPositionData();
            return View(employeeView);
        }

        [HttpPost]
        public IActionResult Update(EmployeeViewModel employeeViewModel)
        {
            try
            {
                EmployeeEntity employeeEntity = new EmployeeEntity()
                {
                    Id = employeeViewModel.Id,
                    Code = employeeViewModel.Code,
                    Name = employeeViewModel.Name,
                    Email = employeeViewModel.Email,
                    Gender = employeeViewModel.Gender,
                    DOB = employeeViewModel.DOB,
                    DOE = employeeViewModel.DOE,
                    DOR = employeeViewModel.DOR,
                    Address = employeeViewModel?.Address,
                    BasicSalary = employeeViewModel.BasicSalary,
                    Phone = employeeViewModel?.Phone,
                    PositionId = employeeViewModel.PositionId,
                    DepartmentId = employeeViewModel.DepartmentId,
                    ModifiedAt = DateTime.Now,
                    CreatedAt = employeeViewModel.CreatedOn
                };
                _dbContext.Employees.Update(employeeEntity);
                _dbContext.SaveChanges();
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
                EmployeeEntity employeeEntity = _dbContext.Employees.Find(id);
                if (employeeEntity != null)
                {
                    employeeEntity.IsInActive = true;
                    _dbContext.Employees.Update(employeeEntity);
                    _dbContext.SaveChanges();
                    TempData["Info"] = "Delete success when delete the record.";
                }
            }
            catch (Exception e)
            {
                TempData["Info"] = "Error occur when delete the record." + e.Message;
            }
            return RedirectToAction("List");
        }
    }
}
