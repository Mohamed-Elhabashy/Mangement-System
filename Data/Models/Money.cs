using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mangement_System.Data.Models
{
    public class Money
    {
        public int MoneyId { get; set; }
        [Required(ErrorMessage = "لابد من إدخال الاسم")]
        public string MoneyName { get; set; }
        [Required(ErrorMessage = "لابد من إدخال المبلغ")]
        public float TotalMoney { get; set; }
        public DateTime DateOfMoney { get; set; }
        public int TypeMoney { get; set; }//1 import ---- 2 export ----- 3 Donation
    }
}
