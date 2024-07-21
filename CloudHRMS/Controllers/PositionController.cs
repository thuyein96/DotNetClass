using CloudHRMS.DAO;
using CloudHRMS.Models.Entities;
using CloudHRMS.Models.ViewModels;
using CloudHRMS.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace CloudHRMS.Controllers
{
    public class PositionController : Controller
    {
        private readonly IPositionService _positionService;

        //constructor injection for ApplicationDbContext
        public PositionController(IPositionService positionService)
        {
            _positionService = positionService;
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

                var isAlreadyExist = _positionService.IsAlreadyExist(positionViewModel);
                if (isAlreadyExist)
                {
                    ViewData["Info"] = "The Position is already exit.";
                    ViewData["Status"] = false;
                    return View(positionViewModel);
                }
                _positionService.Create(positionViewModel);
                ViewData["Info"] = "Successfully save the record to the system.";
                ViewData["Status"] = true;
            }
            catch (Exception e)
            {
                ViewData["Info"] = "Error occur when the record save to the system."+e.Message;
                ViewData["Status"] = false;
            }
            return View(positionViewModel);
        }
        public IActionResult List()
        {
            var positions = _positionService.GetAll();
            return View(positions);
        }
        public IActionResult Edit(string id)
        {
            PositionViewModel positionViewModel = _positionService.GetById(id);
            return View(positionViewModel);
        }
        [HttpPost]
        public IActionResult Update(PositionViewModel positionViewModel)
        {
            try
            {
                //Data Exchange from view Model to Entity
                //ViewModels to Data Models
                var isAlreadyExist = _positionService.IsAlreadyExist(positionViewModel);
                if (isAlreadyExist)
                {
                    return View("Edit", positionViewModel);
                }
                _positionService.Update(positionViewModel);
                TempData["Info"] = "Successfully update the record to the system.";
                TempData["Status"] = true;
            }
            catch (Exception e)
            {
                TempData["Info"] = "Error occur when the record update to the system." + e.Message;
                TempData["Status"] = false;
                return View("Edit", positionViewModel);
            }
            return RedirectToAction("List");//when update success go to List View
        }
        public IActionResult Delete(string id)
        {
            try
            {
                var status = _positionService.Delete(id);
                TempData["Info"] = "Successfully delete";
                TempData["Status"] = false;
            }
            catch (Exception e)
            {
                TempData["info"] = "Error occur when delete the record."+e.Message;
                TempData["Status"] = false;
            }
            return RedirectToAction("List");//when delete success go to List View
        }
    }
}
