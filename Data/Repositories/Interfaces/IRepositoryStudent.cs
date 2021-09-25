using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mangement_System.Data.Repositories.Interfaces
{
    public interface IRepositoryStudent<T>
    {
        IList<T> List();
        T Add(T Entity);
        T Find(int id);
        void update(T Entity);
        void delete(int id);
        IList<T> ListSpecificStudent(int? groupId);
        int NumberOfStudent(bool group);
        void commit();
        IList<T> Search(string name, DateTime begin, DateTime end);
    }
}
