using Mangement_System.Data.Models;
using Mangement_System.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mangement_System.Data.Repositories.DataBaseRepositories
{
    public class StudentDbRepositories : IRepository<Student>
    {
        readonly private EntitiesDbContext dbContext;
        public StudentDbRepositories(EntitiesDbContext _dbContext)
        {
            dbContext = _dbContext;
        }
        public Student Add(Student student)
        {
            dbContext.students.Add(student);
            commit();
            return student;
        }

        public void commit()
        {
            dbContext.SaveChanges();
        }

        public void delete(int id)
        {
            var student = Find(id);
            if (student == null) return;
            dbContext.students.Remove(student);
            commit();
        }

        public Student Find(int id)
        {
            return dbContext.students.FirstOrDefault(s => s.studentId==id);
        }

        public IList<Student> List()
        {
            return dbContext.students.ToList();
        }

        public void update(Student Entity)
        {
            dbContext.students.Update(Entity);
            commit();
        }
    }
}
