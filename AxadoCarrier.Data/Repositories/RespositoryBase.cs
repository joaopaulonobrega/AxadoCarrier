using AxadoCarrier.Data.Context;
using AxadoCarrier.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace AxadoCarrier.Data.Repositories
{
    public class RespositoryBase<T> : IDisposable, IRepositoryBase<T> where T : class
    {
        protected AppContext Db = new AppContext();

        public void Add(T entity)
        {
            var transaction = Db.Database.BeginTransaction();
            
            try
            {
                Db.Set<T>().Add(entity);
                Db.SaveChanges();

                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
            }
            
        }
        
        public IEnumerable<T> GetAll()
        {
            try
            {
                return Db.Set<T>().ToList();
            }
            catch
            {
                throw;
            }
        }

        public T GetById(int id)
        {
            try
            {
                return Db.Set<T>().Find(id);
            }
            catch
            {
                throw;
            }
        }

        public void Remove(T entity)
        {
            var transaction = Db.Database.BeginTransaction();

            try
            {
                Db.Set<T>().Remove(entity);
                Db.SaveChanges();

                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
            }
        }

        public void Update(T entity)
        {
            var transaction = Db.Database.BeginTransaction();

            try
            {
                Db.Entry<T>(entity).State = EntityState.Modified;
                Db.SaveChanges();

                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
            }
        }

        public void Dispose()
        {
            Db.Dispose();
        }
    }
}
