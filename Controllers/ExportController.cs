using Mangement_System.Data.Models;
using Mangement_System.Data.Repositories.Interfaces;
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
    public class ExportController : Controller
    {
        readonly private IRepositoryMoney<Money> MoneyRepo;
        public ExportController(IRepositoryMoney<Money> _MoneyRepo)
        {
            MoneyRepo = _MoneyRepo;
        }
        public ActionResult Index(int? page)
        {
            int pagenumber = page ?? 1;
            var List = MoneyRepo.ListType(2);
            ViewBag.TotalPageProblem = (List.Count() / 25) + (List.Count() % 25 == 0 ? 0 : 1);
            if (pagenumber < 0 || pagenumber > ViewBag.TotalPageProblem) pagenumber = 1;
            ViewBag.Pagenum = pagenumber;
            var model = List.ToPagedList(pagenumber, 25);
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        // POST: ImportController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Money money)
        {
            try
            {
                money.DateOfMoney = DateTime.Now;
                money.TypeMoney = 2;
                MoneyRepo.Add(money);
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
            var money = MoneyRepo.Find(id);
            if (money == null) return RedirectToAction("Index", "Home");
            return View(money);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Money money)
        {
            try
            {
                MoneyRepo.update(money);
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

            MoneyRepo.delete(id);
            return RedirectToAction(nameof(Index));
        }

        
    }
}
