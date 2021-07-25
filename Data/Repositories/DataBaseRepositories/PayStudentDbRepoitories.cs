using Mangement_System.Data.Models;
using Mangement_System.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mangement_System.Data.Repositories.DataBaseRepositories
{
    public class PayStudentDbRepoitories : IRepositoryPayStudent<PayStudent>
    {
        readonly private EntitiesDbContext dbContext;
        public PayStudentDbRepoitories(EntitiesDbContext _dbContext)
        {
            dbContext = _dbContext;
        }
        public PayStudent Add(PayStudent item)
        {
            dbContext.payStudents.Add(item);
            commit();
            return item;
        }

        public void commit()
        {
            dbContext.SaveChanges();
        }

        public void delete(int id)
        {
            var item = Find(id);
            if (item == null) return;
            dbContext.payStudents.Remove(item);
            commit();
        }

        public PayStudent Find(int id)
        {
            return dbContext.payStudents.
                Include(p=>p.student).
                FirstOrDefault(p => p.PayStudentId == id);
        }

        public IList<PayStudent> List(int groupid)
        {
            return dbContext.payStudents.Include(p => p.student).Where(p => p.student.GroupId == groupid).ToList();
        }

        public void update(PayStudent item)
        {
            dbContext.payStudents.Update(item);
            commit();
        }
    }
}
