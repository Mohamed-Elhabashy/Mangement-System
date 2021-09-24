using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mangement_System.Data.Models
{
    public class Employee
    {
        
        public int EmployeeId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string country { get; set; }
        [Required]
        public string Role { get; set; }
        [Required]
        public string Areaofstudy { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string NationalId { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string gender { get; set; }
        [Required]
        public string Socialstatus { get; set; } // الحاله الاجتماعيه
        [Required]
        public float Salary { get; set; }
        [Required]
        public DateTime Birthdate { get; set; }
        [Required]
        public DateTime JoinInStaff { get; set; }
    }
}
