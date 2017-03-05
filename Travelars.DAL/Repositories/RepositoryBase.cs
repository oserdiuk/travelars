using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using Travelars.Domain;

namespace Travelars.DAL.Repositories
{
    public class RepositoryBase<TEntity> : IRepository<TEntity>
        where TEntity : Entity
    {
        private readonly DbSet<TEntity> _items;

        public RepositoryBase(DbContext dbContext)
        {
            _items = dbContext.Set<TEntity>();
        }

        public TEntity Get(Guid id)
        {
            return _items.Find(id);
        }

        public IEnumerable<TEntity> Get()
        {
            return _items.AsNoTracking();
        }

        public void Create(TEntity item)
        {
            _items.Add(item);
        }

        public void Update(TEntity item)
        {
            _items.AddOrUpdate(item);
        }

        public void Delete(Guid id)
        {
            var item = Get(id);
            _items.Remove(item);
        }

        public IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> where)
        {
            var items = _items.Where(where);
            return items;
        }

        public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> where)
        {
            var item = _items.FirstOrDefault(where);
            return item;
        }
    }
}
