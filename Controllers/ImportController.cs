﻿using Mangement_System.Data.Models;
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
    public class ImportController : Controller
    {
        readonly private IRepositoryMoney<Money> MoneyRepo;
        public ImportController(IRepositoryMoney<Money> _MoneyRepo)
        {
            MoneyRepo = _MoneyRepo;
        }
        public ActionResult Index()
        {
            var List = MoneyRepo.ListType(1);
            return View(List);
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
                money.TypeMoney = 1;
                MoneyRepo.Add(money);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        
        public ActionResult Edit(int id)
        {
            var money = MoneyRepo.Find(id);
            if (money == null) return RedirectToAction("Index", "Home");
            return View(money);
        }

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

        public ActionResult Delete(int id)
        {
            var money = MoneyRepo.Find(id);
            if (money == null) return RedirectToAction("Index", "Home");
            return View(money);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Money money)
        {
            try
            {
                MoneyRepo.delete(money.MoneyId);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}