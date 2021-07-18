using Mangement_System.Data.Models;
using Mangement_System.Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mangement_System.Controllers
{
    public class WaitingStudentController : Controller
    {
        readonly private IRepositoryStudent<Student> students;
        public WaitingStudentController(IRepositoryStudent<Student> _students)
        {
            students = _students;
        }
        public ActionResult Index()
        {
            var list = students.ListSpecificStudent(null);
            return View(list);
        }

        
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Student student)
        {
            try
            {
                students.Add(student);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        
        public ActionResult Edit(int id)
        {
            var student = students.Find(id);
            return View(student);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Student student)
        {
            try
            {
                students.update(student);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            var student = students.Find(id);
            return View(student);
        }

        // POST: WaitingStudentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Student student)
        {
            try
            {
                students.delete(student.studentId);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
