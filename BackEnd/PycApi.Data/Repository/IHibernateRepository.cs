using PycApi.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace PycApi.Data
{
    public interface IHibernateRepository<T> where T : class
    {
        void BeginTransaction();
        void Commit();
        void Rollback();
        void CloseTransaction();
        void  Save(T entity);
        void Save1(Account account);
        void Update(T entity);
        void Delete(int id);
        List<T> GetAll();
        T GetById(int id);
        T GetByStringId(string id);
        IEnumerable<T> Find(Expression<Func<T, bool>> expression);
        IEnumerable<T> Where(Expression<Func<T, bool>> where);
        IQueryable<T> Entities { get; }
    }
}
