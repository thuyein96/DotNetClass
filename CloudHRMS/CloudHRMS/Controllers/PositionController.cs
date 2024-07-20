using CloudHRMS.DAO;
using CloudHRMS.Models.Entities;
using CloudHRMS.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace CloudHRMS.Controllers
{
    public class PositionController : Controller
    {      
        private readonly CloudHRMSApplicationDbContext _dbContext;
        //constcutror injection for ApplicationDbContext
        public PositionController(CloudHRMSApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Entry()
        {
            PositionViewModel positionViewModel = new PositionViewModel()
            {
                Level = 1
            };
            return View(positionViewModel);
        }
        [HttpPost]
        public IActionResult Entry(PositionViewModel positionViewModel)
        {
            try
            {

                var isAlreadyExist = _dbContext.Positions.Where(w=>(w.Code== positionViewModel.Code || w.Name==positionViewModel.Name)&&w.IsInActive).Any();
                if (isAlreadyExist)
                {
                    ViewData["Info"] = "The Position is already exit.";
                    ViewData["Status"] = false;
                    return View(positionViewModel);
                }
                //Data Exchange from view Model to Entity
                //ViewModels to Data Models 
                PositionEntity positionEntity = new PositionEntity()
                {
                    Id = Guid.NewGuid().ToString(),//new random 36 char string ...
                    Code = positionViewModel.Code,
                    Name = positionViewModel.Name,
                    Level = positionViewModel.Level,
                    CreatedAt = DateTime.Now//set the current date time 
                };
                _dbContext.Positions.Add(positionEntity);//add the entity to the dbContext.
                _dbContext.SaveChanges();//saving the record to the database.
                ViewData["Info"] = "Successfully save the record to the system.";
                ViewData["Status"] = true;
            }
            catch (Exception e)
            {
                ViewData["Info"] = "Error occur when the recrod save to the system."+e.Message;
                ViewData["Status"] = false;
            }
            return View(positionViewModel);
        }
        public IActionResult List()
        {
            //DTO >>Data Transfer Object in here from DataModels to ViewModels
            IList<PositionViewModel> positions=_dbContext.Positions.Where(w=>!w.IsInActive).Select(s=>new PositionViewModel
            {
                Id=s.Id,
                Code=s.Code,
                Name=s.Name,
                Level=s.Level
            }).ToList();
            return View(positions);//passing the position view models to the views
        }
        public IActionResult Edit(string id)
        {
            PositionViewModel positionView = _dbContext.Positions.Where(w => w.Id == id && !w.IsInActive).Select(s => new PositionViewModel
            {
                Id=s.Id,
                Code = s.Code,
                Name = s.Name,
                Level = s.Level,
                CreatedOn=s.CreatedAt,
                UpdatedOn=s.ModifiedAt
            }).FirstOrDefault();
            return View(positionView);
        }
        [HttpPost]
        public IActionResult Update(PositionViewModel positionViewModel)
        {
            try
            {
                //Data Exchange from view Model to Entity
                //ViewModels to Data Models 
                PositionEntity positionEntity = new PositionEntity()
                {
                    Id= positionViewModel.Id,
                    Code = positionViewModel.Code,
                    Name = positionViewModel.Name,
                    Level = positionViewModel.Level,
                    ModifiedAt = DateTime.Now,
                    CreatedAt=positionViewModel.CreatedOn
                };
                _dbContext.Positions.Update(positionEntity);//updae the entity to the dbContext.
                _dbContext.SaveChanges();//updating the record to the database.
                ViewData["Info"] = "Successfully update the record to the system.";
                ViewData["Status"] = true;
            }
            catch (Exception e)
            {
                ViewData["Info"] = "Error occur when the record update to the system." + e.Message;
                ViewData["Status"] = false;
            }
            return RedirectToAction("List");//when update success go to List View
        }
        public IActionResult Delete(string id)
        {
            try
            {
                PositionEntity positionEntity = _dbContext.Positions.Find(id);
                if (positionEntity != null)
                {
                    positionEntity.IsInActive = true;
                    _dbContext.Positions.Update(positionEntity);
                    _dbContext.SaveChanges();//saving the record to the database.
                    TempData["info"] = "Delete success when delete the record.";
                }
            }
            catch (Exception e)
            {
                TempData["info"] = "Error occur when delete the record."+e.Message;
            }
            return RedirectToAction("List");//when delete success go to List View
        }
    }
}
