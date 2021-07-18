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
                emplyee = EmployeeRepo.List().Where(e => e.Role == "محفظ")
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
                    GroupName=model.GroupName,
                    EmployeeId=model.EmployeeId
                };
                groups.Add(group);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: GroupController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: GroupController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: GroupController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: GroupController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
