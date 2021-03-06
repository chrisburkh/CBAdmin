﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CBAdmin.Models;
using CBAdmin.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Raven.Client.Documents.Linq;

namespace CBAdmin.Controllers
{
    public class StudentController : Controller
    {
        private IService<Student> _service;

        public StudentController(IService<Student> studentservice)
        {
            _service = studentservice;
        }
        // GET: Student
        public async Task<IActionResult> Index(string SearchString)
        {
            IList<Student> list = null;

            if (!String.IsNullOrEmpty(SearchString))
            {
                var session = _service.GetSession();

                list = (from employee in session.Query<Student>()
                        where employee.FirstMidName.StartsWith(SearchString) ||
                        employee.LastName.StartsWith(SearchString)
                        select employee).ToList();

                return View(list);

            }
            else
            {
                // all
                list = (await _service.GetEntityListAsynch());
            }




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
        public ActionResult Create(Student student)
        {
            try
            {
                // TODO: we have to set it this way so that ravendb creates a nice uuid for us. Remove to a better place.
                if (student.Id == null)
                {
                    student.Id = string.Empty;
                }
                _service.WriteEntity(student);

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
            var student = _service.GetEntity(id);

            return View(student);

        }


        // POST: Student/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Student student)
        {
            try
            {
                _service.WriteEntity(student);

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
        public ActionResult Delete(Student student)
        {


            _service.DeleteEntity(student.Id);

            return RedirectToAction("Index");
            //       return View();

        }
    }
}