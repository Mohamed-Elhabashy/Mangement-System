using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mangement_System.Data.Models
{
    public class PaySalary
    {
        public int PaySalaryId { get; set; }
        public DateTime date { get; set; }
        public int EmployeeId { get; set; }
        public Employee employee { get; set; }
    }
}
