using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mangement_System.Data.Models;
namespace Mangement_System.ViewModels.Student
{
    public class StudentAddInGroupViewModel
    {
        public Mangement_System.Data.Models.Student student { get; set; }
        public IList<Mangement_System.Data.Models.Group> Listgroup { get; set; }
    }
}
