﻿using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Repository.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Repository
{
    public class UnitOfWork : IUnitOfWork
    {

        protected AHPContext DbContext { get; private set; }

        public UnitOfWork(AHPContext dbContext)
        {
            if (dbContext == null)
            {
                throw new ArgumentNullException("DbContext");
            }
            DbContext = dbContext;
        }

        public Task<int> AddAsync<T>(T entity) where T : class
        {
            EntityEntry dbEntityEntry = DbContext.Entry(entity);
            if (dbEntityEntry.State != EntityState.Detached)
            {
                dbEntityEntry.State = EntityState.Added;
            }
            else
            {
                DbContext.Set<T>().Add(entity);
            }
            return Task.FromResult(1);
        }

        public Task<int> UpdateAsync<T>(T entity) where T : class
        {
            EntityEntry dbEntityEntry = DbContext.Entry(entity);
            if (dbEntityEntry.State == EntityState.Detached)
            {
                DbContext.Set<T>().Attach(entity);
            }
            dbEntityEntry.State = EntityState.Modified;

            return Task.FromResult(1);
        }

        public Task<int> DeleteAsync<T>(T entity) where T : class
        {
            EntityEntry dbEntityEntry = DbContext.Entry(entity);
            if (dbEntityEntry.State != EntityState.Deleted)
            {
                dbEntityEntry.State = EntityState.Deleted;
            }
            else
            {
                DbContext.Set<T>().Attach(entity);
                DbContext.Set<T>().Remove(entity);
            }
            return Task.FromResult(1);
        }

        public Task<int> DeleteAsync<T>(Guid id) where T : class
        {
            var entity = DbContext.Set<T>().Find(id);
            if (entity == null)
            {
                return Task.FromResult(0);
            }
            return DeleteAsync<T>(entity);
        }

        public async Task<int> CommitAsync()
        {
            int result = 0;
            using (TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                result = await DbContext.SaveChangesAsync();
                scope.Complete();
            }
            return result;
        }

        public void Dispose()
        {
            DbContext.Dispose();
        }

        public Task<int> GetAsync<T>(T entity) where T : class
        {
            if (entity == null)
            {
                return Task.FromResult(0);
            }
            return GetAsync<T>(entity);
        }
        public Task<int> GetAsync<T>(Guid id) where T : class
        {
            var entity = DbContext.Set<T>().Find(id);
            if (entity == null)
            {
                return Task.FromResult(0);
            }
            return GetAsync<T>(entity);
        }

        //public Task<int> GetAllAsync<T>(T id) where T : class
        //{
        //    //var entity = DbContext.Set<T>().GetType
        //    //if (entity == null)
        //    //{
        //    //    return Task.FromResult(0);
        //    //}
        //    //return GetAsync<T>(entity);

        //}
    }
}
