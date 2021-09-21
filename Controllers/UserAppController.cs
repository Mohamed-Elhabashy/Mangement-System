using Mangement_System.Data.Models;
using Mangement_System.Data.Repositories.Interfaces;
using Mangement_System.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mangement_System.Controllers
{
    public class UserAppController : Controller
    {
        readonly private IRepositoryUser<User> Users;
        public UserAppController(IRepositoryUser<User> _Users)
        {
            Users = _Users;
        }
        public ActionResult Index()
        {
            var list = Users.List();
            return View(list);
        }
        public ActionResult Delete(string id)
        {
            Users.delete(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
