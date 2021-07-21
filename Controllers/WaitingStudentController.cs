using Mangement_System.Data.Models;
using Mangement_System.Data.Repositories.Interfaces;
using Mangement_System.ViewModels.Student;
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
        readonly private IRepository<Group> groups;
        public WaitingStudentController(IRepositoryStudent<Student> _students, IRepository<Group> _groups)
        {
            students = _students;
            groups = _groups;
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
                student.Joinplace = DateTime.Now;
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
                int? groupId = students.Find(student.studentId).GroupId;
                students.delete(student.studentId);
                if (groupId == null)
                {
                    //return to page Index that show all Waiting Student
                    return RedirectToAction(nameof(Index));
                }
                //return to page Detials in Group that show all Student in this group
                return RedirectToAction("Details","Group",new { id=groupId });
            }
            catch
            {
                return View();
            }
        }
        public ActionResult AddToGroup(int id)
        {
            var student= students.Find(id);
            if (student == null) return Redirect("Index");
            StudentAddInGroupViewModel model = new StudentAddInGroupViewModel
            {
                student = student,
                Listgroup = groups.List()
            };
            return View(model);
        }
        [HttpPost]
        public ActionResult AddToGroup(int StudentId,int GroupId)
        {
            try
            {
                var student = students.Find(StudentId);
                var LastGroupId = student.GroupId;
                student.GroupId = GroupId;
                students.update(student);
                if (LastGroupId==null)
                return RedirectToAction(nameof(Index));
                return RedirectToAction("Details","Group",new { id=GroupId});
            }
            catch
            {
                return View();
            }
        }

    }
}
