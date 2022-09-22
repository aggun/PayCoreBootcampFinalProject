using NHibernate;
using PycApi.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace PycApi.Data
{
    public class HibernateRepository<T> : IHibernateRepository<T> where T : class
    {
        private readonly ISession session;
        private ITransaction transaction;

        public HibernateRepository(ISession session)
        {
            this.session = session;
        }

        public IQueryable<T> Entities => session.Query<T>();

        public void BeginTransaction()
        {
            transaction = session.BeginTransaction();
        }

        public void Commit()
        {
            transaction.Commit();
        }

        public void Rollback()
        {
            transaction.Rollback();
        }

        public void CloseTransaction()
        {
            if (transaction != null)
            {
                transaction.Dispose();
                transaction = null;
            }
        }

        public void Save(T entity)
        {
            session.Save(entity);
        }

        public void Save1(Account account)
        {
            session.Save(account);
        }

        public void Update(T entity)
        {
            session.Update(entity);
        }

        public void Delete(int id)
        {
            var entity = GetById(id);
            if (entity != null)
            {
                session.Delete(entity);
            }
        }

        public List<T> GetAll()
        {
            return session.Query<T>().ToList();
        }

        public T GetById(int id)
        {
            var entity = session.Get<T>(id);
            return entity;
        }

        public T GetByStringId(String id)
        {
            var entity = session.Get<T>(id);
            return entity;
        }


        public IEnumerable<T> Where(Expression<Func<T, bool>> where)
        {
            return session.Query<T>().Where(where).AsQueryable();
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
        {
            return session.Query<T>().Where(expression).ToList();
        }
    }
}
