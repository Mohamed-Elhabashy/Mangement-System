using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Mangement_System.ViewModels.Latepayment
{
    public class LatePaymentViewModel
    {
        public IList<Mangement_System.Data.Models.Group> groups { get; set; }
        public ICollection<Mangement_System.Data.Models.Student> students { get; set; }
    }
}
