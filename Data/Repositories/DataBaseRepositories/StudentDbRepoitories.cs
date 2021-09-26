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

        public List<Student> ListSpecificStudent(int? groupId)
        {
            
           return dbContext.students
                .Include(g => g.Group)
                .Where(s => s.GroupId == groupId).ToList();
            
        }
        public int NumberOfStudent(bool group)
        {

            if (group == true)
            {
                return dbContext.students
                 .Include(g => g.Group)
                 .Where(s => s.GroupId != null).ToList().Count();
            }
            
            return dbContext.students
                 .Include(g => g.Group)
                 .Where(s => s.GroupId == null).ToList().Count();

        }

        public void update(Student student)
        {
            dbContext.students.Update(student);
            commit();
        }
        public IList<Student> Search(string name, int? year)
        {
            if (name == null) name = "";
            if (year == null)
            {
                return dbContext.students.Where(item =>
                       item.StudentName.Contains(name)
                    ).ToList();
            }
            return dbContext.students.Where(item =>
                   item.StudentName.Contains(name)
                   && item.Birthdate.Year==year
                ).ToList();
        }
    }
}
