using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace WebAppMVC.DAL.Conexao
{
    public class Repositorio<T> : IRepositorio<T>, IDisposable where T : class
    {
        private FirstWebAppMVCEntities Context;

        protected Repositorio()
        {
            Context = new FirstWebAppMVCEntities();
        }
        public IQueryable<T> Get(Expression<Func<T, bool>> predicate)
        {
            return Context.Set<T>().Where(predicate);
        }
        public IQueryable<T> GetTodos()
        {
            return Context.Set<T>();
        }
        public T First(Expression<Func<T, bool>> predicate)
        {
            return Context.Set<T>().Where(predicate).FirstOrDefault();
        }
        public T Find(params object[] key)
        {
            return Context.Set<T>().Find(key);
        }
        public IEnumerable<T> GetAll()
        {
            return Context.Set<T>().ToList();
        }
        public IEnumerable<T> GetAllOrderBy(Func<T, object> keySelector)
        {
            return Context.Set<T>().OrderBy(keySelector).ToList();
        }
        public IEnumerable<T> GetAllOrderByDescending(Func<T, object> keySelector)
        {
            return Context.Set<T>().OrderByDescending(keySelector).ToList();
        }
        public void Commit()
        {
            Context.SaveChanges();
        }
        public void Add(T entity)
        {
            Context.Set<T>().Add(entity);
        }
        public void Update(T entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
        }
        public void Excluir(Func<T, bool> predicate)
        {
            Context.Set<T>()
                .Where(predicate).ToList()
                .ForEach(del => Context.Set<T>().Remove(del));
        }
        public void Delete(T entity)
        {
            Context.Set<T>().Remove(entity);
        }
        public void Dispose()
        {
            if (Context != null)
            {
                Context.Dispose();
            }
            GC.SuppressFinalize(this);
        }
    }
}
