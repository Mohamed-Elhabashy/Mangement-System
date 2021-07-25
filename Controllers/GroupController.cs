using Mangement_System.Data.Models;
using Mangement_System.Data.Repositories.Interfaces;
using Mangement_System.ViewModels.Group;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mangement_System.Controllers
{
    public class GroupController : Controller
    {
        readonly private IRepository<Group> groups;
        readonly private IRepositoryPayStudent<PayStudent> paystudentRepo;
        readonly private IRepository<Employee> EmployeeRepo;
        public GroupController(IRepository<Group> _groups, IRepository<Employee> _EmployeeRepo, IRepositoryPayStudent<PayStudent> _paystudentRepo)
        {
            groups = _groups;
            EmployeeRepo = _EmployeeRepo;
            paystudentRepo = _paystudentRepo;
        }
        public ActionResult Index()
        {
            var list = groups.List();
            return View(list);
        }

        public ActionResult Create()
        {
            var model = new GroupViewModel()
            {
                emplyee = EmployeeRepo.List().Where(e => e.Role == "محفظ").ToList()
            };
            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GroupViewModel model)
        {
            try
            {
                var group = new Group()
                {
                    GroupName = model.GroupName,
                    EmployeeId = model.EmployeeId
                };
                groups.Add(group);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            var group = groups.Find(id);

            if (group == null) return RedirectToAction("Index", "Home");

            var model = new GroupViewModel()
            {
                GroupId = id,
                GroupName = group.GroupName,
                emplyee = EmployeeRepo.List().Where(e => e.Role == "محفظ" && e.EmployeeId != group.EmployeeId).ToList()
            };
            model.emplyee.Insert(0,group.employee);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(GroupViewModel model)
        {
            try
            {
                Group item = new Group
                {
                    groupId = model.GroupId,
                    GroupName = model.GroupName,
                    EmployeeId = model.EmployeeId
                };
                groups.update(item);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Details(int id)
        {
            var group = groups.Find(id);
            if(group==null) return RedirectToAction("Index", "Home");
            return View(group);
        }
        public ActionResult Delete(int id)
        {
            var group = groups.Find(id);
            if (group == null) return RedirectToAction("Index", "Home");
            return View(group);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Group group)
        {
            try
            {
                groups.delete(group.groupId);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        public ActionResult payment(int id)
        {
            ViewBag.GroupId = id;
            var list = paystudentRepo.List(id);
            return View(list);
        }
        public ActionResult paystudent(int id)
        {
            var model = new PayStudentViewModel {
                students = groups.Find(id).Students,
                groupId=id
            };
            return View(model);
        }
        [HttpPost]
        public ActionResult paystudent(PayStudentViewModel model)
        {
            try
            {
                var item = new PayStudent
                {
                    TotalPay = model.TotalPay,
                    StudentId = model.StudentId,
                    date = DateTime.Now
                };
                paystudentRepo.Add(item);

                return RedirectToAction("payment",new {id=model.groupId });
            }
            catch
            {
                return View();
            }
        }
        public ActionResult DeletePayStudent(int id,int groupId)
        {
            var model = paystudentRepo.Find(id);
            if (model == null) return RedirectToAction("payment", new { id = groupId });
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePayStudent(int paystudentId, int groupId, IFormCollection collection)
        {
            try
            {
                paystudentRepo.delete(paystudentId);
                return RedirectToAction("payment", new { id = groupId });
            }
            catch
            {
                return View();
            }
        }
        public ActionResult EditPayStudent(int id, int groupId)
        {
            var item = paystudentRepo.Find(id);

            if (item == null) return RedirectToAction("payment", new { id = groupId });

            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditPayStudent(PayStudent model)
        {
            
                paystudentRepo.update(model);
                return RedirectToAction("payment", new { id = 1 });
            
            
        }
    }
}
