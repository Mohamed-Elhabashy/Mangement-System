using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mangement_System.Data.Models
{
    public class Group
    {
        public Group()
        {
            Students = new HashSet<Student>();
        }
        public int groupId { get; set; }
        public string GroupName { get; set; }
        public virtual ICollection<Student> Students{ get; set; }
        public int EmployeeId { get; set; }
        public Employee employee { get; set; }
    }
}
