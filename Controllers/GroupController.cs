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
        readonly private IRepository<Employee> EmployeeRepo;
        public GroupController(IRepository<Group> _groups, IRepository<Employee> _EmployeeRepo)
        {
            groups = _groups;
            EmployeeRepo = _EmployeeRepo;
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
    }
}
