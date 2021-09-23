using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mangement_System.Data.Models
{
    public class Employee
    {
        
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string country { get; set; }
        public string Role { get; set; }
        public string Areaofstudy { get; set; }
        public string Phone { get; set; }
        public string NationalId { get; set; }
        public string Address { get; set; }
        public string gender { get; set; }
        public string Socialstatus { get; set; } // الحاله الاجتماعيه
        public float Salary { get; set; }
        public DateTime Birthdate { get; set; }
        public DateTime JoinInStaff { get; set; }
    }
}
