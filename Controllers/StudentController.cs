using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CBAdmin.Models;
using CBAdmin.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CBAdmin.Controllers
{
    public class StudentController : Controller
    {
        private IStudentService _service;

        public StudentController(IStudentService studentservice)
        {
            _service = studentservice;
        }
        // GET: Student
        public async Task<IActionResult> Index()
        {
            var list = (await _service.GetStudentListAsynch());

            return View(list);
        }

        // GET: Student/Details/5
        public ActionResult Details(string id)
        {
            var student = _service.GetStudent(id);
            return View(student);
        }

        // GET: Student/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Student/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Student student)
        {
            try
            {
                // TODO: Auslagern
                _service.SaveStudent(student);

                return RedirectToAction("Index");
            }
            catch
            {
                return View(student);
            }
        }

        // GET: Student/Edit/5
        public ActionResult Edit(string id)
        {
            var student = _service.GetStudent(id);
            return View(student);
        }

        // POST: Student/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Student student)
        {
            try
            {
                // TODO: Auslagern
                _service.SaveStudent(student);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Student/Delete/5
        public ActionResult Delete(string id)
        {
            var student = _service.GetStudent(id);
            return View(student);
        }

        // POST: Student/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Student student)
        {
            try
            {

                _service.DeleteStudent(student.Id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}