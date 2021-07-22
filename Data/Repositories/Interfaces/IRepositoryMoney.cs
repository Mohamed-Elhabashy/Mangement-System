using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mangement_System.Data.Repositories.Interfaces
{
    public interface IRepositoryMoney<T>
    {
        IList<T> List();
        T Add(T Entity);
        T Find(int id);
        IList<T> ListType(int type);
        void update(T Entity);
        void delete(int id);
        void commit();
    }
}
