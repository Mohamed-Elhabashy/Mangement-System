using Mangement_System.Data.Models;
using Mangement_System.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mangement_System.Data.Repositories.DataBaseRepositories
{
    public class MoneyDbRepoitories : IRepositoryMoney<Money>
    {
        readonly private EntitiesDbContext dbContext;
        public MoneyDbRepoitories(EntitiesDbContext _dbContext)
        {
            dbContext = _dbContext;
        }
        public Money Add(Money money)
        {
            dbContext.money.Add(money);
            commit();
            return money;
        }

        public void commit()
        {
            dbContext.SaveChanges();
        }

        public void delete(int id)
        {
            var money = Find(id);
            if (money == null) return;
            dbContext.money.Remove(money);
            commit();
        }

        public Money Find(int id)
        {
            return dbContext.money.FirstOrDefault(m => m.MoneyId == id);
        }

        public IList<Money> List()
        {
            return dbContext.money.ToList();
        }

        public IList<Money> ListType(int type)
        {
            return dbContext.money.Where(m => m.TypeMoney == type).ToList();
        }

        public void update(Money money)
        {
            dbContext.money.Update(money);
            commit();
        }
    }
}
