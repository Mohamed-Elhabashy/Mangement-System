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
    public class EmployeeController : Controller
    {
        readonly private IRepository<Employee> employee;
        public EmployeeController(IRepository<Employee> _employee)
        {
            employee = _employee;
        }
        public ActionResult Index()
        {
            var list = employee.List();
            return View(list);
        }

        
        public ActionResult Create()
        {
            return View();
        }

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

        public ActionResult Edit(int id)
        {
            var item = employee.Find(id);
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Employee item)
        {
            try
            {
                employee.update(item);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            var item = employee.Find(id);
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Employee item)
        {
            try
            {
                employee.delete(item.EmployeeId);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
