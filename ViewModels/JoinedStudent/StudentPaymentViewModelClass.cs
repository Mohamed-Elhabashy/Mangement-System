using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mangement_System.ViewModels.JoinedStudent
{
    public class StudentPaymentViewModelClass
    {
        public int Student_id { get; set; }
        public int? group_id { get; set; }
        public string Student_Name { get; set; }
        public string Group_Name { get; set; }
        public List<string> LastPayment { get; set; }

    }
}
