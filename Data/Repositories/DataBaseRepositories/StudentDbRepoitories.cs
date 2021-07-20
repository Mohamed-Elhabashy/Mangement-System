using Mangement_System.Data.Models;
using Mangement_System.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mangement_System.Data.Repositories.DataBaseRepositories
{
    public class StudentDbRepoitories : IRepositoryStudent<Student>
    {
        readonly private EntitiesDbContext dbContext;
        public StudentDbRepoitories(EntitiesDbContext _dbContext)
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
            return dbContext.students
                .Include(g=>g.Group)
                .FirstOrDefault(s => s.studentId == id);
        }

        public IList<Student> List()
        {
            return dbContext.students
                .Include(g => g.Group)
                .ToList();
        }

        public IList<Student> ListSpecificStudent(int? groupId)
        {
            
           return dbContext.students
                .Include(g => g.Group)
                .Where(s => s.GroupId == groupId).ToList();
            
        }

        public void update(Student student)
        {
            dbContext.students.Update(student);
            commit();
        }
    }
}
