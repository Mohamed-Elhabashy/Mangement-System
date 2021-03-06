using Mangement_System.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mangement_System.Data.Repositories.Interfaces
{
    public interface IRepositoryPayStudent<T>
    {
        IList<T> List(int groupid);
        IList<T> LastThreePayment(int? groupid,int student_id);

        Boolean Add(T Entity);
        T Find(int id);
        void update(T Entity);
        void delete(int id);
        IList<PayStudent> ListAll();
        void commit();
        IList<T> Search(string name);
        Boolean IsPayment(int studentId, DateTime date);
    }
}
