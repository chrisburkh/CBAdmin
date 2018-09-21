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

            return View(list);

        }

        // GET: Student/Details/5
        public ActionResult Details(string id)
        {
            var student = _service.GetEntity(id);
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