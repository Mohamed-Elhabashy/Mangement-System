using Mangement_System.Data.Models;
using Mangement_System.Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;
namespace Mangement_System.Controllers
{

    [Authorize(Roles = "Admin,secretary")]
    public class JoinedStudentController : Controller
    {
        readonly private IRepositoryStudent<Student> students;
        public JoinedStudentController(IRepositoryStudent<Student> _students)
        {
            students = _students;
        }
        public ActionResult Index(int? page)
        {
            int pagenumber = page ?? 1;
            ViewBag.function = "Index";
            var model = students.JoinedStudents();
            ViewBag.TotalPageProblem = (model.Count() / 25) + (model.Count() % 25 == 0 ? 0 : 1);
            if (pagenumber < 0 || pagenumber > ViewBag.TotalPageProblem) pagenumber = 1;
            ViewBag.Pagenum = pagenumber;
            var list = model.ToPagedList(pagenumber, 25);
            TempData["JoinedStudentController"] = true;
            return View(list);
        }
        public ActionResult Filter(int? page, string Name)
        {
            int pagenumber = page ?? 1;
            ViewBag.function = "Filter";
            ViewBag.name = Name;
            var model = students.Search(Name,true, null);
            ViewBag.TotalPageProblem = (model.Count() / 25) + (model.Count() % 25 == 0 ? 0 : 1);
            if (pagenumber < 0 || pagenumber > ViewBag.TotalPageProblem) pagenumber = 1;
            ViewBag.Pagenum = pagenumber;
            var list = model.ToPagedList(pagenumber, 25);

            TempData["JoinedStudentController"] = true;
            return View("Index", list);
        }
    }
}
