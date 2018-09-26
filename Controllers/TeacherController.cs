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
    public class TeacherController : Controller
    {
        private IService<Teacher> _service;

        public TeacherController(IService<Teacher> teacherService)
        {
            _service = teacherService;
        }
        // GET: Teacher
        public async Task<IActionResult> Index()
        {

            var list = (await _service.GetEntityListAsynch());

            return View(list);

        }

        // GET: Teacher/Details/5
        public ActionResult Details(string id)
        {
            var student = _service.GetEntity(id);
            return View(student);
        }

        // GET: Teacher/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Teacher/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Teacher teacher)
        {
            try
            {
                // TODO: we have to set it this way so that ravendb creates a nice uuid for us. Remove to a better place.
                if (teacher.Id == null)
                {
                    teacher.Id = string.Empty;
                }
                _service.WriteEntity(teacher);

                return RedirectToAction("Index");
            }
            catch
            {
                return View(teacher);
            }
        }

        // GET: Teacher/Edit/5
        public ActionResult Edit(string id)
        {
            var student = _service.GetEntity(id);
            return View(student);

        }

        // POST: Teacher/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Teacher teacher)
        {
            try
            {
                _service.WriteEntity(teacher);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Teacher/Delete/5
        public ActionResult Delete(string id)
        {
            var student = _service.GetEntity(id);

            return View();
        }

        // POST: Teacher/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Teacher teacher)
        {

            _service.DeleteEntity(teacher.Id);

            return RedirectToAction("Index");

        }
    }
}