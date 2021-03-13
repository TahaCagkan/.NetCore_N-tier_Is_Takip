using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
    public class JobController : Controller
    {
        private readonly IJobService _jobService;
        private readonly IEmergencyService _emergencyService;
       public JobController(IJobService jobService, IEmergencyService emergencyService)
        {
            _jobService = jobService;
            _emergencyService = emergencyService;
        }
        public IActionResult Index()
        {
            TempData["Active"] = "job";
            //aciliyetle tamamlanmayanları getir
            List<Job> jobs=_jobService.GetEmergencyNotOK();
            List<JobListViewModel> models = new List<JobListViewModel>();
            foreach (var job in jobs)
            {
                JobListViewModel model = new JobListViewModel()
                {
                    Id = job.Id,
                    Name = job.Name,
                    Status = job.Status,
                    CreateDate = job.CreateDate,
                    Description = job.Description,
                    Emergency = job.Emergency,
                    EmergencyId = job.EmergencyId

                };
                models.Add(model);
            }
            return View(models);
        }

        public IActionResult AddJob()
        {
            TempData["Active"] = "job";

            ViewBag.Emergency = new SelectList(_emergencyService.GetAll(),"Id", "Definition");
            return View(new JobAddViewModel());
        }
        //Görev ekleme
        [HttpPost]
        public IActionResult AddJob(JobAddViewModel model)
        {
            if(ModelState.IsValid)
            {
                _jobService.Save(new Job
                {
                    Description = model.Description,
                    Name = model.Name,
                    EmergencyId = model.EmergencyId
                });
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult UpdateJob(int id)
        {
            TempData["Active"] = "job";

            var job = _jobService.GetId(id);
            JobUpdateViewModel model = new JobUpdateViewModel
            {
                Id = job.Id,
                Description = job.Description,
                EmergencyId = job.EmergencyId,
                Name = job.Name
            };
            ViewBag.Emergency = new SelectList(_emergencyService.GetAll(), "Id", "Definition",job.EmergencyId);

            return View(model);
        }

        [HttpPost]
        public IActionResult UpdateJob(JobUpdateViewModel model)
        {
            if(ModelState.IsValid)
            {
                _jobService.Update(new Job()
                {
                    Id = model.Id,
                    Description = model.Description,
                    EmergencyId = model.EmergencyId,
                    Name = model.Name
                });
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult DeleteJob(int id)
        {
            _jobService.Delete(new Job { Id = id });
            return Json(null);
        }
    }
}
