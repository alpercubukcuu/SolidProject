using BussinesLayer.Concrete;
using BussinesLayer.FluentValidation;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UILayer.Controllers
{
    public class JobController : Controller
    {
        JobManager jobManager = new JobManager(new EfJobDal());
        JobValidator validationRules = new JobValidator();
        public IActionResult Index()
        {
          
            var job = jobManager.TGetList();
            return View(job);
        }

        [HttpGet]
        public IActionResult AddJob()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddJob(Job job)
        {
            ValidationResult result = validationRules.Validate(job);
            if (result.IsValid)
            {
                jobManager.TInsert(job);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);

                }
            }
            return View();
        }

        [HttpGet]
        public IActionResult UpdateJob(int id)
        {
            var job = jobManager.TGetById(id);
            return View(job);
        }
        [HttpPost]
        public IActionResult UpdateJob(Job job)
        {
            ValidationResult result = validationRules.Validate(job);
            if (result.IsValid)
            {
                jobManager.TUpdate(job);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);

                }
            }
            return View();
        }



        public IActionResult DeleteJob(int id)
        {
            var job = jobManager.TGetById(id);
            jobManager.TDelete(job);
            return RedirectToAction("Index");
        }

        public IActionResult DetailJob(int id)
        {
            var job = jobManager.TGetById(id);
            jobManager.TDelete(job);
            return RedirectToAction("Index");
        }

    }
}
