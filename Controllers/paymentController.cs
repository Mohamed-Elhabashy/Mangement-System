using Mangement_System.Data.Models;
using Mangement_System.Data.Repositories.Interfaces;
using Mangement_System.ViewModels.JoinedStudent;
using Mangement_System.ViewModels.payment;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;
namespace Mangement_System.Controllers
{
    [Authorize(Roles = "Admin,secretary")]
    public class paymentController : Controller
    {
        readonly private IRepository<Group> groups;
        readonly private IRepositoryPayStudent<PayStudent> paystudentRepo;
        public paymentController(IRepositoryPayStudent<PayStudent> _paystudentRepo, IRepository<Group> _groups)
        {
            paystudentRepo = _paystudentRepo;
            groups = _groups;
        }
        // GET: paymentController
        public ActionResult Index(int? page)
        {
            int pagenumber = page ?? 1;
            ViewBag.function = "Index";
            var model = paystudentRepo.ListAll();
            ViewBag.TotalPageProblem = (model.Count() / 25) + (model.Count() % 25 == 0 ? 0 : 1);
            if (pagenumber < 0 || pagenumber > ViewBag.TotalPageProblem) pagenumber = 1;
            ViewBag.Pagenum = pagenumber;
            var list = model.ToPagedList(pagenumber, 25);
            return View(list);
        }
        public ActionResult Filter(int? page, string Name)
        {
            int pagenumber = page ?? 1;
            ViewBag.function = "Filter";
            ViewBag.name = Name;
            var model = paystudentRepo.Search(Name);
            ViewBag.TotalPageProblem = (model.Count() / 25) + (model.Count() % 25 == 0 ? 0 : 1);
            if (pagenumber < 0 || pagenumber > ViewBag.TotalPageProblem) pagenumber = 1;
            ViewBag.Pagenum = pagenumber;
            var list = model.ToPagedList(pagenumber, 25);
            return View("Index", list);
        }

        public ActionResult ListGroups()
        {
            var list = groups.List();
            var model = new PaymentViewModel()
            {
                groups = list
            };
            return View(model);
        }

        public ActionResult SelectGroup(int? GroupId)
        {
            int GId;
            if (GroupId == null)
            {
                return RedirectToAction(nameof(ListGroups));
            }
            GId = (int)GroupId;
            var listStudent = groups.Find(GId).Students.ToList();
            var ListPayment=getPaymentStudent(listStudent);
            var Listgroups = groups.List();
            var model = new PaymentViewModel()
            {
                groups = Listgroups,
                students = ListPayment
            };
            return View("ListGroups", model);
        }
        
        public ActionResult AddPayment(int studentid,string func)
        {
            ViewBag.StudentId = studentid;
            TempData[func] = true;
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddPayment(PayStudent model)
        {
            try
            {
                model.DateOfPay = DateTime.Now;
                var result = paystudentRepo.Add(model);
                if (result == false)
                {
                    return RedirectToAction(nameof(AlreadyPay));
                }
                if (TempData.ContainsKey("JoinedStudentController")){
                    TempData.Remove("JoinedStudentController");
                    return RedirectToAction("index", "JoinedStudent");
                }
                if (TempData.ContainsKey("FunctionSelectGroup"))
                {
                    TempData.Remove("FunctionSelectGroup");
                    return RedirectToAction("ListGroups");
                }
                else if(TempData.ContainsKey("FunctionLatePayment"))
                {
                    TempData.Remove("FunctionLatePayment");
                    return RedirectToAction("Index", "Latepayment");
                }
                return RedirectToAction(nameof(ListGroups));
            }
            catch
            {
                return View();
            }
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            paystudentRepo.delete(id);
            return RedirectToAction(nameof(Index));
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            var model = paystudentRepo.Find(id);
            if (model == null) return RedirectToAction("Index", "Home");
            return View(model);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PayStudent model)
        {
            try
            {
                paystudentRepo.update(model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        public ActionResult AlreadyPay()
        {
            return View();
        }
        public List<StudentPaymentViewModelClass> getPaymentStudent(List<Student> list)
        {
            var ListStudent = new List<StudentPaymentViewModelClass>();
            foreach (var model in list)
            {

                var last3payment = paystudentRepo.LastThreePayment(model.GroupId, model.studentId);
                StudentPaymentViewModelClass item = new StudentPaymentViewModelClass()
                {
                    Student_id = model.studentId,
                    Student_Name = model.StudentName,
                    group_id = model.GroupId,
                    Group_Name = model.Group.GroupName,
                    LastPayment = new List<string>() { }
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
    }
}
