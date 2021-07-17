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
        public PaySalary Add(PaySalary Entity)
        {
            throw new NotImplementedException();
        }

        public void commit()
        {
            throw new NotImplementedException();
        }

        public void delete(int id)
        {
            throw new NotImplementedException();
        }

        public PaySalary Find(int id)
        {
            throw new NotImplementedException();
        }

        public IList<PaySalary> List()
        {
            throw new NotImplementedException();
        }

        public void update(PaySalary Entity)
        {
            throw new NotImplementedException();
        }
    }
}
