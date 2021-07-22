using Mangement_System.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mangement_System.ViewModels.Group
{
    public class GroupViewModel
    {
        public int GroupId { get; set; }
        [Required(ErrorMessage = "لابد من إدخال اسم المجموعة")]
        public string GroupName { get; set; }
        [Required(ErrorMessage = "لابد من إدخال اسم المحفظ")]
        public int EmployeeId { get; set; }
        public List<Employee> emplyee { get; set; }
    }
}
