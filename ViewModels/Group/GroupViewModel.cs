using Mangement_System.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mangement_System.ViewModels.Group
{
    public class GroupViewModel
    {
        public string GroupName { get; set; }
        public int EmployeeId { get; set; }
        public IEnumerable<Employee> emplyee { get; set; }
    }
}
