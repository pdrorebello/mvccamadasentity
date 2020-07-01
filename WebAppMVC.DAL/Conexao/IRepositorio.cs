using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace WebAppMVC.DAL.Conexao
{
    public interface IRepositorio<T> where T : class
    {
        IQueryable<T> Get(Expression<Func<T, bool>> predicate);
        T First(Expression<Func<T, bool>> predicate);
        T Find(params object[] key);
        IEnumerable<T> GetAll();
        IQueryable<T> GetTodos();
        IEnumerable<T> GetAllOrderBy(Func<T, object> keySelector);
        IEnumerable<T> GetAllOrderByDescending(Func<T, object> keySelector);
        void Add(T entity);
        void Update(T entity);
        void Excluir(Func<T, bool> predicate);
        void Delete(T entity);
        void Commit();
        void Dispose();
    }
}
