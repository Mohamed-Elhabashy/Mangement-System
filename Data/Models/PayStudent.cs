using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mangement_System.Data.Models
{
    public class PayStudent
    {
        public int PayStudentId { get; set; }
        public float TotalPay { get; set; }
        public DateTime date { get; set; }
        public DateTime DateOfPay { get; set; }
        public int StudentId { get; set; }
        public Student student { get; set; }
    }
}
