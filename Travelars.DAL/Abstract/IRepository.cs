using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Travelars.DAL.Repositories
{
    public interface IRepository<T>
    {
        T Get(Guid id);

        IEnumerable<T> Get();

        IEnumerable<T> Get(Expression<Func<T, bool>> where);

        T FirstOrDefault(Expression<Func<T, bool>> where);

        void Create(T item);

        void Update(T item);

        void Delete(Guid id);
    }
}