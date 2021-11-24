using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Mangement_System.ViewModels.payment
{
    public class PaymentViewModel
    {
        public IList<Mangement_System.Data.Models.Group> groups { get; set; }
        public ICollection<Mangement_System.ViewModels.JoinedStudent.StudentPaymentViewModelClass> students { get; set; }
    }
}
