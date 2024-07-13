using CloudHRMS.DAO;
using CloudHRMS.Models.Entities;
using CloudHRMS.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CloudHRMS.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly CloudHRMSApplicationDbContext _dbContext;
        public DepartmentController(CloudHRMSApplicationDbContext dbContext)
        {
            _dbContext = dbContext;   
        }
        public IActionResult Entry() => View();

        [HttpPost]
        public IActionResult Entry(DepartmentViewModel departmentViewModel)
        {
            try
            {
                DepartmentEntity departmentEntity = new DepartmentEntity()
                {
                    Id = Guid.NewGuid().ToString(),
                    Code = departmentViewModel.Code,
                    Name = departmentViewModel.Name,
                    ExtensionPhone = departmentViewModel.ExtensionPhone,
                    CreatedAt = DateTime.Now
                };
                _dbContext.Departments.Add(departmentEntity);
                _dbContext.SaveChanges();
                ViewData["Info"] = "Successfully save the record to the system.";
                ViewData["Status"] = true;
            }
            catch (Exception e)
            {
                ViewData["Info"] = "Error occur when the record save to the system." + e.Message;
                ViewData["Status"] = false;
            }
            return View();
        }

        public IActionResult List()
        {
            IList<DepartmentViewModel> departments = _dbContext.Departments.Select(s=>new DepartmentViewModel
            {
                Id = s.Id,
                Name = s.Name,
                ExtensionPhone = s.ExtensionPhone
            }).ToList();
            return View(departments);
        }

        public IActionResult Edit(string id)
        {
            DepartmentViewModel departmentView = _dbContext.Departments.Where(w => w.Id == id && !w.IsInActive).Select(s => new DepartmentViewModel
            {
                Id = s.Id,
                Code = s.Code,
                Name = s.Name,
                ExtensionPhone = s.ExtensionPhone,
                CreatedOn = s.CreatedAt,
                UpdatedOn = s.ModifiedAt
            }).FirstOrDefault();
            return View(departmentView);
        }

        [HttpPost]
        public IActionResult Update(DepartmentViewModel departmentViewModel)
        {
            try
            {
                DepartmentEntity departmentEntity = new DepartmentEntity()
                {
                    Id = departmentViewModel.Id,
                    Code = departmentViewModel.Code,
                    Name = departmentViewModel.Name,
                    ExtensionPhone = departmentViewModel.ExtensionPhone,
                    ModifiedAt = DateTime.Now,
                    CreatedAt = departmentViewModel.CreatedOn
                };
                _dbContext.Departments.Update(departmentEntity);
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
                DepartmentEntity departmentEntity = _dbContext.Departments.Find(id);
                if (departmentEntity != null)
                {
                    departmentEntity.IsInActive = true;
                    _dbContext.Departments.Update(departmentEntity);
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
