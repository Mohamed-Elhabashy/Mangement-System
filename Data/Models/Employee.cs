using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mangement_System.Data.Models
{
    public class Employee
    {
        public Employee()
        {
            PaySalaries = new HashSet<PaySalary>();
        }
        public int EmployeeId { get; set; }
        public string country { get; set; }
        public float Salary { get; set; }
        public DateTime Birthdate { get; set; }
        public virtual ICollection<PaySalary> PaySalaries{ get; set; }
    }
}
