using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mangement_System.Data.Models
{
    public class Student
    {
        public int studentId { get; set; }
        
        [Required(ErrorMessage = "لابد من إدخال اسم الطالب")]
        public string StudentName { get; set; }
        [Required(ErrorMessage = "لابد من إدخال المدرسة")]
        public string school { get; set; }
        [Required(ErrorMessage = "لابد من إدخال رقم الوالد")]
        public string phone { get; set; }
        [Required(ErrorMessage = "لابد من إدخال وظيفة الوالد")]
        public string FatherJob { get; set; }
        [Required(ErrorMessage = "لابد من إدخال تاريخ الميلاد")]
        public DateTime Birthdate { get; set; }
        public DateTime Joinplace { get; set; }
        public int? GroupId { get; set; }
        public Group Group { get; set; }
    }
}
