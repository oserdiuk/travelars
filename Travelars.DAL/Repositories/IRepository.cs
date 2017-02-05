using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Travelars.DAL.Repositories
{
    public interface IRepository<T>
    {
        T Get(string id);

        IEnumerable<T> Get();

        IEnumerable<T> Get(Expression<Func<T, bool>> where);

        T FirstOrDefault(Expression<Func<T, bool>> where);

        void Create(T item);

        void Update(T item);

        void Delete(string id);
    }
}