using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using StudentsWebApp.DAL;
using StudentsWebApp.Models;

namespace StudentsWebApp.Controllers
{
    [RequireHttps]
    public class HomeController : Controller
    {
        private readonly IStudStorage _studStorage;

        public HomeController(IStudStorage studStorage)
        {
            _studStorage = studStorage;
        }

        public IActionResult Index()
        {
            var students = _studStorage.GetAll().ToList();
            return View(students);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null) return NotFound();
            ViewBag.Groups = _studStorage.GetGroups();
            Student student = _studStorage.GetStudentById((int)id);
            return View(student);
        }
        [HttpGet]
        public IActionResult PartialSearch(string name)
        {
            var s = _studStorage.GetStudentByName(name);
            return PartialView("PartialSearch", s);
        }


        public JsonResult PartialSearchJson(Student student)
        {

            return Json(student);
        }

        [HttpGet]
        public IActionResult Add(int groupID)
        {
            ViewBag.Groups = _studStorage.GetGroups();
            Student student = new Student() { GroupID = groupID};
            return View("Edit", student);
        }

        [HttpPost]
        public IActionResult Edit(Student student)
        {
            if (ModelState.IsValid)
            {
                Student stud = student;
                _studStorage.AddOrUpdate(stud);
                return Redirect("Index");
            }
            ViewBag.Groups = _studStorage.GetGroups();
            return View(student);
            
        }

        public ActionResult Delete(int id)
        {
            Student student = _studStorage.GetStudentById(id);
            _studStorage.Delete(student);
            return RedirectToAction("Index");
        }
        
    }
}
