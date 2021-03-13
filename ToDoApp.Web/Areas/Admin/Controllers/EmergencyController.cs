using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoApp.Business.Abstract;
using ToDoApp.Entities.Concrete;
using ToDoApp.Web.Areas.Admin.Models;

namespace ToDoApp.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class EmergencyController : Controller
    {
        private readonly IEmergencyService _emergencyService;
        public EmergencyController(IEmergencyService emergencyService)
        {
            _emergencyService = emergencyService;
        }
        public IActionResult Index()
        {
            TempData["Active"] = "emergency";
            List<Emergency> emergencies = _emergencyService.GetAll();
            List<EmergencyListViewModel> model = new List<EmergencyListViewModel>();

            foreach (var item in emergencies)
            {
                EmergencyListViewModel emergencyModel = new EmergencyListViewModel();
                emergencyModel.Id = item.Id;
                emergencyModel.Definition = item.Definition;

                model.Add(emergencyModel);
            }
            return View(model);
        }

        public IActionResult AddEmergency()
        {
            TempData["Active"] = "emergency";

            return View(new EmergencyAddViewModel());
        }

        [HttpPost]
        public IActionResult AddEmergency(EmergencyAddViewModel model)
        {
            if (ModelState.IsValid)
            {
                _emergencyService.Save(new Emergency()
                {
                    Definition = model.Definition
                });
                return RedirectToAction("Index");

            }
            return View(model);
        }

        public IActionResult UpdateEmergency(int id)
        {
            TempData["Active"] = "emergency";

            var emergency = _emergencyService.GetId(id);
            EmergencyUpdateViewModel model = new EmergencyUpdateViewModel
            {
                Id = emergency.Id,
                Definition = emergency.Definition
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult UpdateEmergency(EmergencyUpdateViewModel model)
        {
            if(ModelState.IsValid)
            {
                _emergencyService.Update(new Emergency
                {
                    Id = model.Id,
                    Definition = model.Definition
                });
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}
