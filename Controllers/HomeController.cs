using Mangement_System.Data.Models;
using Mangement_System.Data.Repositories.Interfaces;
using Mangement_System.Models;
using Mangement_System.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mangement_System.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        readonly private IRepositoryMoney<Money> MoneyRepo;
        readonly private IRepositoryStudent<Student> students;
        readonly private IRepository<Group> groups;
        readonly private IRepositoryPayStudent<PayStudent> paystudentRepo;
        readonly private IRepository<Employee> EmployeeRepo;
        public HomeController(IRepositoryMoney<Money> _MoneyRepo,
            IRepositoryStudent<Student> _students,
            IRepository<Group> _groups,
            IRepositoryPayStudent<PayStudent> _paystudentRepo,
            IRepository<Employee> _EmployeeRepo
            )
        {

            MoneyRepo = _MoneyRepo;
            students = _students;
            groups = _groups;
            paystudentRepo = _paystudentRepo;
            EmployeeRepo = _EmployeeRepo;

        }

        public IActionResult Index()
        {
            var model = new HomeViewModel()
            {
                NumberWaitingStudent= students.NumberOfStudent(false),
                NumberStudent = students.NumberOfStudent(true),
                NumberGroup = groups.List().Count(),
                Employee = EmployeeRepo.List().Count(),

            };
            float sum = 0;
            foreach(var x in MoneyRepo.List())
            {
                if (x.TypeMoney == 2) sum -= x.TotalMoney;
                else sum += x.TotalMoney;
            } 
            foreach(var x in paystudentRepo.ListAll())
            {
                sum += x.TotalPay;
            }
            model.TotalMoney = sum;
            return View(model);
        }


    }
}
