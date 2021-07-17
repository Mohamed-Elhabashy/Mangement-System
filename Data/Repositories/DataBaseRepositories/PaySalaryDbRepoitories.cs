using Mangement_System.Data.Models;
using Mangement_System.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mangement_System.Data.Repositories.DataBaseRepositories
{
    public class PaySalaryDbRepoitories : IRepository<PaySalary>
    {
        readonly private EntitiesDbContext dbContext;
        public PaySalaryDbRepoitories(EntitiesDbContext _dbContext)
        {
            dbContext = _dbContext;
        }
        public PaySalary Add(PaySalary paySalary)
        {
            dbContext.PaySalaries.Add(paySalary);
            commit();
            return paySalary;
        }

        public void commit()
        {
            dbContext.SaveChanges();
        }

        public void delete(int id)
        {
            var paysalary = Find(id);
            if (paysalary == null) return;
            dbContext.PaySalaries.Remove(paysalary);
            commit();
        }

        public PaySalary Find(int id)
        {
            return dbContext.PaySalaries.FirstOrDefault(p => p.PaySalaryId == id);
        }

        public IList<PaySalary> List()
        {
            return dbContext.PaySalaries.ToList();
        }

        public void update(PaySalary paySalary)
        {
            dbContext.PaySalaries.Update(paySalary);
            commit();
        }
    }
}
