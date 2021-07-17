﻿using Mangement_System.Data.Models;
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

        public void delete(int id)
        {
            var employee = Find(id);
            if (employee == null) return;
            dbContext.Employees.Remove(employee);
            commit();
        }

        public Employee Find(int id)
        {
            return dbContext.Employees.FirstOrDefault(e => e.EmployeeId == id);
        }

        public IList<Employee> List()
        {
            return dbContext.Employees.ToList();
        }

        public void update(Employee employee)
        {
            dbContext.Employees.Update(employee);
            commit();
        }
    }
}
