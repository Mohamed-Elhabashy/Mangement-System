using Mangement_System.Data.Repositories.Interfaces;
using Mangement_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mangement_System.Data.Repositories.DataBaseRepositories
{
    public class UserDbRepoitories : IRepository<User>
    {
        readonly private ApplicationDbContext dbContext;
        public UserDbRepoitories(ApplicationDbContext _dbContext)
        {
            dbContext = _dbContext;
        }
        public User Add(User user)
        {
            dbContext.Users.Add(user);
            commit();
            return user;
        }

        public void commit()
        {
            dbContext.SaveChanges();
        }

        public void delete(int id)
        {
            var user = Find(id);
            if (user == null) return;
            dbContext.Users.Remove(user);
            commit();
        }

        public User Find(int id)
        {
            throw new NotImplementedException();
        }

        public IList<User> List()
        {
            return dbContext.Users.ToList();
        }

        public void update(User user)
        {
            dbContext.Users.Update(user);
            commit();
        }
    }
}
