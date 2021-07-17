using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mangement_System.Data.Models
{
    public class Student
    {
        public int studentId { get; set; }
        public string StudentName { get; set; }
        public string school { get; set; }
        public string phone { get; set; }
        public string FatherJob { get; set; }
        public DateTime Birthdate { get; set; }
        public DateTime Joinplace { get; set; }
        public int? GroupId { get; set; }
        public Group? Group { get; set; }
    }
}
