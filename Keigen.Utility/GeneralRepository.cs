using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace Keigen.Utility
{
    public class GeneralRepository<T>:IRepository<T> where T:class
    {
        internal DbContext Context;
        internal DbSet<T> DbSet;

        public GeneralRepository(DbContext context)
        {
            if (context==null)
            {
                throw new ArgumentNullException("context");                
            }
            Context = context;
            DbSet = context.Set<T>();
        }

        #region IRepository<T> 成员

        public IQueryable<T> GetAll()
        {
            return DbSet;
        }

        public IEnumerable<T> GetBySql(string query, params object[] parameters)
        {
            return DbSet.SqlQuery(query, parameters).ToList();
        }

        public IEnumerable<T> Get(System.Linq.Expressions.Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "")
        {
            IQueryable<T> query = DbSet;
            if (filter!=null)
            {
                query.Where(filter);
            }
            query = includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
            return orderBy != null ? orderBy(query).ToList() : query.ToList();
        }

        public T GetbyID(object id)
        {
            return DbSet.Find(id);
        }

        public void Add(T entity)
        {
            DbEntityEntry dbEntityEntry = Context.Entry(entity);
            if (dbEntityEntry.State!= EntityState.Detached)
            {
                dbEntityEntry.State = EntityState.Added;
            }else
            {
                DbSet.Add(entity);
            }
        }

        public void Update(T entity)
        {
            DbEntityEntry dbEntityEntry = Context.Entry(entity);
            if (dbEntityEntry.State== EntityState.Detached)
            {
                DbSet.Attach(entity);
            }
            dbEntityEntry.State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            DbEntityEntry dbEntityEntry = Context.Entry(entity);
            if (dbEntityEntry.State!= EntityState.Deleted)
            {
                dbEntityEntry.State = EntityState.Deleted;
            }
            else
            {
                DbSet.Attach(entity);
                DbSet.Remove(entity);
            }
        }

        public void Delete(object id)
        {
            var entity = GetbyID(id);
            if (entity==null)
            {
                return;
            }
            Delete(entity);
        }

        #endregion
    }
}
