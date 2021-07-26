using Mangement_System.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mangement_System.Data
{
    public class EntitiesDbContext:DbContext
    {
        public EntitiesDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Group> groups { get; set; }
        public DbSet<Money> money { get; set; }
        public DbSet<Student> students { get; set; }
        public DbSet<PayStudent> payStudents { get; set; }
    }

}
