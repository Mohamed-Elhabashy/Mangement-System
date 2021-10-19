using Mangement_System.Data.Models;
using Mangement_System.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mangement_System.Data.Repositories.DataBaseRepositories
{
    public class EmployeeDbRepoitories : IRepository<Employee>
    {
        readonly private EntitiesDbContext dbContext;
        public EmployeeDbRepoitories(EntitiesDbContext _dbContext)
        {
            dbContext = _dbContext;
        }
        public Employee Add(Employee employee)
        {
            dbContext.Employees.Add(employee);
            commit();
            return employee;
        }

        public void commit()
        {
            dbContext.SaveChanges();
        }

        public Boolean delete(int id)
        {
            try
            {
                var listgroup = dbContext.groups.Where(g => g.EmployeeId == id).ToList();
                if (listgroup.Count() > 0) return false;
                var employee = Find(id);
                if (employee == null) return false;
                dbContext.Employees.Remove(employee);
                commit();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Employee Find(int id)
        {
            return dbContext.Employees.FirstOrDefault(e => e.EmployeeId == id);
        }

        public IList<Employee> List()
        {
            return dbContext.Employees.ToList();
        }

        public Boolean update(Employee employee)
        {
            var listgroup = dbContext.groups.Where(g => g.EmployeeId == employee.EmployeeId).ToList();
            if (listgroup.Count() > 0 && employee.Role!="محفظ") return false;
            dbContext.Employees.Update(employee);
            commit();
            return true;
        }
    }
}
