using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using APICrud.Models;
namespace APICrud.Repositories
{
  
        public abstract class RepositoryBases<T> where T : class
        {
            protected DbContext Context { get; }


            public RepositoryBases(DbContext context)
            {
                Context = context ?? throw new ArgumentNullException(nameof(context));
            }

            public virtual IEnumerable<T> GetAll()
            {
                return Context.Set<T>().ToList();
            }

            public virtual IEnumerable<T> GetByCondition(Expression<Func<T, bool>> expression)
            {
                return Context.Set<T>().Where(expression).ToList();
            }

            public virtual T GetById(int id)
            {
                return Context.Set<T>().Find(id);
            }

            public virtual void Create(T entity)
            {
                Context.Set<T>().Add(entity);
            }

            public virtual void Update(T entity)
            {
                Context.Set<T>().Update(entity);
            }

            public virtual void Delete(T entity)
            {
                Context.Set<T>().Remove(entity);
            }

            public virtual bool SaveChanges()
            {
                return Context.SaveChanges() >= 0;
            }
        }
    
}
