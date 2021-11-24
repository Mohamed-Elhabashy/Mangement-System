using Mangement_System.Data.Models;
using Mangement_System.Data.Repositories.Interfaces;
using Mangement_System.ViewModels.JoinedStudent;
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
        readonly private IRepositoryPayStudent<PayStudent> paystudentRepo;
        public JoinedStudentController(IRepositoryStudent<Student> _students, IRepositoryPayStudent<PayStudent> _paystudentRepo)
        {
            students = _students;
            paystudentRepo = _paystudentRepo;
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
            var Model = getPaymentStudent(list);
            
            return View(Model);
        }
        public List<StudentPaymentViewModelClass> getPaymentStudent(IPagedList<Student> list)
        {
            var ListStudent = new List<StudentPaymentViewModelClass>();
            foreach (var model in list)
            {

                var last3payment = paystudentRepo.LastThreePayment(model.GroupId, model.studentId);
                StudentPaymentViewModelClass item = new StudentPaymentViewModelClass()
                {
                    Student_id=model.studentId,
                    Student_Name=model.StudentName,
                    group_id =model.GroupId,
                    Group_Name=model.Group.GroupName,
                    LastPayment=new List<string>() {}
                };
                while (item.LastPayment.Count() < 3)
                {
                    if (last3payment.Count() > 0)
                    {
                        item.LastPayment.Add(String.Format("{0:MM/yyyy}", last3payment.FirstOrDefault().date));
                        last3payment.RemoveAt(0);
                    }
                    else
                    {
                        item.LastPayment.Add("----/--");
                    }
                }
                ListStudent.Add(item);
            }
            return ListStudent;
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
            var Model = getPaymentStudent(list);
            TempData["JoinedStudentController"] = true;
            return View("Index", Model);
        }
    }
}
