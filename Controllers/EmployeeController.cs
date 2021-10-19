using Mangement_System.Data.Models;
using Mangement_System.Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mangement_System.Controllers
{

    [Authorize]
    public class EmployeeController : Controller
    {
        readonly private IRepository<Employee> employee;
        public EmployeeController(IRepository<Employee> _employee)
        {
            employee = _employee;
        }
        [Authorize(Roles = "Admin,secretary")]
        public ActionResult Index()
        {
            var list = employee.List();
            return View(list);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee item)
        {
            try
            {
                item.JoinInStaff = DateTime.Now;
                employee.Add(item);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            var item = employee.Find(id);
            return View(item);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Employee item)
        {
            try
            {
               
                if(employee.update(item)==false)
                    return RedirectToAction("Cannot");
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            if (employee.delete(id) == true)
                return RedirectToAction(nameof(Index));
            return RedirectToAction("Cannot");
        }
        public ActionResult Cannot()
        {
            return View();
        }

    }
}
