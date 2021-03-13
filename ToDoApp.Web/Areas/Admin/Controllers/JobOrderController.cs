using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
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
    public class JobOrderController : Controller
    {
        private readonly IAppUserService _appUserService;
        private readonly IJobService _jobService;
        private readonly UserManager<AppUser> _userManager;
        private readonly IDocumentService _documentService;

        public JobOrderController(IAppUserService appUserService, IJobService jobService, UserManager<AppUser> userManager, IDocumentService documentService)
        {
            _userManager = userManager;
            _jobService = jobService;
            _appUserService = appUserService;
            _documentService = documentService;
        }

        public IActionResult Index()
        {
            TempData["Active"] = "joborder";
            //var model = _appUserService.GetNotAdmin();

            List<Job> jobs = _jobService.GetAllTable();
            List<JobListAllViewModel> models = new List<JobListAllViewModel>();

            foreach (var item in jobs)
            {
                JobListAllViewModel model = new JobListAllViewModel();
                model.Id = item.Id;
                model.Description = item.Description;
                model.Emergency = item.Emergency;
                model.AppUser = item.AppUser;
                model.CreateDate = item.CreateDate;
                model.Rapors = item.Rapors;
                models.Add(model);
            }

            return View(models);
        }
        //Rapor detayı
        public IActionResult Details(int id)
        {
            TempData["Active"] = "joborder";

            var job = _jobService.GetReportId(id);
            JobListAllViewModel model = new JobListAllViewModel();
            model.Id = job.Id;
            model.Name = job.Name;
            model.Rapors = job.Rapors;
            model.Description = job.Description;
            model.AppUser = job.AppUser;
            
            return View(model);
        }

        //Excel çıktı 
        public IActionResult GetExcel(int id)
        {
           return File(_documentService.TransferExcel(_jobService.GetReportId(id).Rapors), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",Guid.NewGuid()+".xlsx");
        }

        public IActionResult GetPdf(int id)
        {
          var path =  _documentService.TransferPdf(_jobService.GetReportId(id).Rapors);

            return File(path,"application/pdf",Guid.NewGuid()+".pdf");
        }

        //göreve personel atama,  kkkk.com.tr/?s=emre
        public IActionResult SendPerson(int id,string s,int paginals = 1)
        {
            TempData["Active"] = "joborder";

            ViewBag.ActivePage = paginals;

            //ViewBag.TotalPage = (int)Math.Ceiling((double)_appUserService.GetNotAdmin().Count / 3);

            ViewBag.SearchBy = s;

            int totalPage;

            //acil işler
            var jobs = _jobService.GetEmergencyId(id);
            //admin olmayanlar
            var personals = _appUserService.GetNotAdmin(out totalPage,s, paginals);

            ViewBag.TotalPage = totalPage;

            List<AppUserListViewModel> appUserListModel = new List<AppUserListViewModel>();
            foreach (var item in personals)
            {
                AppUserListViewModel model = new AppUserListViewModel();
                model.Id = item.Id;
                model.Name = item.Name;
                model.SurName = item.Surname;
                model.Email = item.Email;
                model.Picture = item.Picture;
                appUserListModel.Add(model);
            }

            ViewBag.Personals = appUserListModel;

            JobListViewModel jobModel = new JobListViewModel();

            jobModel.Id = jobs.Id;
            jobModel.Name = jobs.Name;
            jobModel.Description = jobs.Description;
            jobModel.Emergency = jobs.Emergency;
            jobModel.CreateDate = jobs.CreateDate;

            return View(jobModel);
        }

        [HttpPost]
        public IActionResult SendPerson(PersonToJobViewModel model)
        {
            var updateJob=_jobService.GetId(model.JobId);
            updateJob.AppUserId = model.PersonId;
            _jobService.Update(updateJob);

            return RedirectToAction("Index");
        }

        //Personeli görevlendirme
        public IActionResult PersonToJob(PersonToJobViewModel model)
        {
            TempData["Active"] = "joborder";

            var user = _userManager.Users.FirstOrDefault(x => x.Id == model.PersonId);

            var job = _jobService.GetEmergencyId(model.JobId);

            AppUserListViewModel userModel = new AppUserListViewModel();
            userModel.Id = user.Id;
            userModel.Name = user.Name;
            userModel.Picture = user.Picture;
            userModel.SurName = user.Surname;
            user.Email = user.Email;


            JobListViewModel jobModel = new JobListViewModel();
            jobModel.Id = job.Id;
            jobModel.Description = job.Description;
            jobModel.Emergency = job.Emergency;
            jobModel.Name = job.Name;

            PersonToJobListViewModel personJobModel = new PersonToJobListViewModel();

            personJobModel.AppUser = userModel;
            personJobModel.Job = jobModel;

            return View(personJobModel);
        }
    }
}
