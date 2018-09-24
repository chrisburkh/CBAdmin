using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CBAdmin.Models;
using CBAdmin.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CBAdmin.Controllers
{
    public class ClassController : Controller
    {
        private IService<Class> _service;

        public ClassController(IService<Class> classService)
        {
            _service = classService;
        }
        // GET: Student
        public async Task<IActionResult> Index()
        {

            var list = (await _service.GetEntityListAsynch());

            var session = _service.GetSession();

            var clazzes = session.Query<Class>().Include(r => r.TeacherID).Include(r => r.CourseID).ToList<Class>();

            //IList<Class> orders = session.Query<Class>().Incl

            foreach (Class clazz in clazzes)
            {
                clazz.Teacher = session.Load<Teacher>(clazz.TeacherID);
                clazz.Course = session.Load<Course>(clazz.CourseID);
            }

            return View(clazzes);

        }

        // GET: Student/Details/5
        public ActionResult Details(string id)
        {
            //var student = _service.GetEntity(id);

            var session = _service.GetSession();

            var clazz = session.Include("TeacherID").Include("CourseID").Load<Class>(id);

            clazz.Teacher = session.Load<Teacher>(clazz.TeacherID);
            clazz.Course = session.Load<Course>(clazz.CourseID);

            return View(clazz);
        }

        // GET: Student/Create
        public ActionResult Create()
        {

            var session = _service.GetSession();

            var listTeacher = session.Query<Teacher>().ToList();

            ViewData["TeacherID"] = new SelectList(listTeacher, "Id", "FullName");

            var listCourse = session.Query<Course>().ToList();

            ViewData["CourseID"] = new SelectList(listCourse, "Id", "Subject");
            return View();
        }

        // POST: Student/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Class claz)
        {
            try
            {
                // TODO: we have to set it this way so that ravendb creates a nice uuid for us. Remove to a better place.
                if (claz.Id == null)
                {
                    claz.Id = string.Empty;
                }


                _service.WriteEntity(claz);

                return RedirectToAction("Index");
            }
            catch
            {
                return View(claz);
            }
        }

        // GET: Student/Edit/5
        public ActionResult Edit(string id)
        {
            var student = _service.GetEntity(id);

            var session = _service.GetSession();

            var listTeacher = session.Query<Teacher>().ToList();
            var listCourse = session.Query<Course>().ToList();

            ViewData["TeacherID"] = new SelectList(listTeacher, "Id", "FullName", student.TeacherID);
            ViewData["CourseID"] = new SelectList(listCourse, "Id", "Subject", student.CourseID);

            return View(student);

        }

        // POST: Student/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Class claz)
        {
            try
            {
                _service.WriteEntity(claz);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        private void PopulateDepartmentsDropDownList(object selectedDepartment = null)
        {

            var session = _service.GetSession();

            var list = session.Query<Teacher>().ToList();

            ViewBag.Teacher = new SelectList(list, "Id", "FullName", selectedDepartment);
        }

        // GET: Student/Delete/5
        public ActionResult Delete(string id)
        {
            var student = _service.GetEntity(id);

            return View();
        }

        // POST: Student/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Class claz)
        {
            try
            {

                _service.DeleteEntity(claz);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}