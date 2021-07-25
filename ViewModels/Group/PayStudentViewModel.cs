using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace Mangement_System.ViewModels.Group
{
    public class PayStudentViewModel
    {
        public IEnumerable<Mangement_System.Data.Models.Student> students { get; set; }

        [Required(ErrorMessage = "لابد من اسم الطالب")]
        public int StudentId { get; set; }
        public int? groupId { get; set; }

        [Required(ErrorMessage = "لابد من إدخال المبلغ")]
        public float TotalPay { get; set; }
    }
}
