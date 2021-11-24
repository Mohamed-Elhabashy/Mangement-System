using Mangement_System.Data.Models;
using Mangement_System.Data.Repositories.Interfaces;
using Mangement_System.ViewModels.Latepayment;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mangement_System.Controllers
{
    [Authorize(Roles = "Admin,secretary")]
    public class LatepaymentController : Controller
    {
        readonly private IRepository<Group> groups;
        readonly private IRepositoryPayStudent<PayStudent> paystudentRepo;
        public LatepaymentController(IRepository<Group> _groups, IRepositoryPayStudent<PayStudent> _paystudentRepo)
        {
            groups = _groups;
            paystudentRepo = _paystudentRepo;
        }
        public ActionResult Index()
        {
            var list = groups.List();
            var model = new LatePaymentViewModel()
            {
                groups = list
            };
            return View(model);
        }
        public ActionResult Search(int? GroupId, DateTime date)
        {
            if (GroupId == null)
            {
                return RedirectToAction("Index");
            }
            IList<Student> _students= new List<Student>();
            var allstudent = groups.Find((int)GroupId).Students;
            foreach(var item in allstudent)
            {
                if (paystudentRepo.IsPayment(item.studentId, date) == false)
                    _students.Add(item);
            }

            var list = groups.List();
            var model = new LatePaymentViewModel()
            {
                groups = list,
                students=_students
            };
            return View("Index", model);
        }
    }
}
