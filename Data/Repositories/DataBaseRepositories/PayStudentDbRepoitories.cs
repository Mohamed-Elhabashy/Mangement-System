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
        public Boolean Add(PayStudent item)
        {
            var model = dbContext.payStudents.Where(p => p.StudentId == item.StudentId && p.date == item.date).ToList();
            if (model.Count() > 0)
                return false;
            dbContext.payStudents.Add(item);
            commit();
            return true;
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
                Include(p => p.student).
                FirstOrDefault(p => p.PayStudentId == id);
        }

        public IList<PayStudent> List(int groupid)
        {
            return dbContext.payStudents.Include(p => p.student).Where(p => p.student.GroupId == groupid).ToList();
        }
        public IList<PayStudent> LastThreePayment(int? groupid, int student_id)
        {
            if(groupid ==null)return null;
            return dbContext.payStudents.Include(p => p.student).Where(p => p.student.GroupId == groupid && p.StudentId== student_id).OrderByDescending(p=>p.PayStudentId).Take(3).ToList();
        }
        public IList<PayStudent> ListAll()
        {
            return dbContext.payStudents.Include(p => p.student).ThenInclude(g=>g.Group).OrderByDescending(p => p.PayStudentId).ToList();
        }

        public IList<PayStudent> Search(string name)
        {
            if (name == null) name = "";
            return dbContext.payStudents.Include(s => s.student).ThenInclude(g => g.Group).OrderByDescending(p => p.PayStudentId).Where(item => item.student.StudentName.Contains(name)).ToList();
        }
        
        public void update(PayStudent item)
        {
            var model=dbContext.payStudents.Find(item.PayStudentId);
            model.TotalPay = item.TotalPay;
            model.date = item.date;
            commit();
        }
        Boolean IRepositoryPayStudent<PayStudent>.IsPayment(int studentId, DateTime date)
        {
            var list = dbContext.payStudents.Where(p => p.StudentId == studentId && p.date==date).ToList();
            if(list.Count()>0)
                return true;
            return false;
        }
    }
}
