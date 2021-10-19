using Mangement_System.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mangement_System.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Mangement_System.Data.Repositories.DataBaseRepositories
{
    public class GroupDbRepositories : IRepository<Group>
    {
        readonly private EntitiesDbContext dbContext;
        public GroupDbRepositories(EntitiesDbContext _dbContext)
        {
            dbContext = _dbContext;
        }
        public Group Add(Group group)
        {
            dbContext.groups.Add(group);
            commit();
            return group;
        }

        public void commit()
        {
            dbContext.SaveChanges();
        }

        public Boolean delete(int id)
        {
            
            try
            {
                var group = Find(id);
                if (group == null) return false;
                dbContext.groups.Remove(group);
                commit();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Group Find(int id)
        {
            return dbContext.groups
                .Include(e=>e.employee)
                .Include(s=>s.Students)
                .FirstOrDefault(g => g.groupId == id);
        }

        public IList<Group> List()
        {
            return dbContext.groups
                .Include(e => e.employee)
                .ToList();
        }

        public Boolean update(Group group)
        {
            dbContext.groups.Update(group);
            commit();
            return true;
        }
    }
}
