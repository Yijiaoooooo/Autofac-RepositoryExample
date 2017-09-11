using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RepositoryExample.Models;
using RepositoryExample.Services;

namespace RepositoryExample.Controllers
{
    public class Grade2Controller : Controller
    {
        private readonly IGradeService _gradeService;


        public Grade2Controller(IGradeService gradeService)
        {
            _gradeService = gradeService;
        }

        public ActionResult Index()
        {
            var model = _gradeService.GetAllGrade();
            return View(model);
        }

        public ActionResult Create()
        {
            return View(new Grade());
        }

        [HttpPost]
        public ActionResult Create(Grade grade)
        {
            if (ModelState.IsValid)
            {
                _gradeService.Insert(grade);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int Id)
        {
            var model = _gradeService.GetById(Id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(Grade grade)
        {
            var oldGrade = _gradeService.GetById(grade.Id);
            oldGrade.Name = grade.Name;

            if (ModelState.IsValid)
            {
                _gradeService.Update(grade);
            }
            return RedirectToAction("Index");
        }

        public void Delete(int Id)
        {
            var grade = _gradeService.GetById(Id);
            _gradeService.Delete(grade);
        }
    }
}
