using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mangement_System.Data.Models
{
    public class Money
    {
        public int MoneyId { get; set; }
        public string MoneyName { get; set; }
        public float TotalMoney { get; set; }
        public DateTime DateOfMoney { get; set; }
        public int TypeMoney { get; set; }//1 import ---- 2 export ----- 3 Donation
    }
}
