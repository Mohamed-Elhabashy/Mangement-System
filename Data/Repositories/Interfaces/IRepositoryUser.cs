using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mangement_System.Data.Repositories.Interfaces
{
    public interface IRepositoryUser<T>
    {
        IList<T> List();
        T Add(T Entity);
        T Find(string id);
        void update(T Entity);
        void delete(string id);
        void commit();
    }
}
