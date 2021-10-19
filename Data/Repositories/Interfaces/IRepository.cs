using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mangement_System.Data.Repositories.Interfaces
{
    public interface IRepository<T>
    {
        IList<T> List();
        T Add(T Entity);
        T Find(int id);
        Boolean update(T Entity);
        Boolean delete(int id);
        void commit();
    }
}
