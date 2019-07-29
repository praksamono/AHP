using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Common
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> AddAsync<T>(T entity) where T : class, IBaseEntity;

        Task<int> CommitAsync();

        Task<int> DeleteAsync<T>(T entity) where T : class, IBaseEntity;

        Task<int> DeleteAsync<T>(Guid id) where T : class, IBaseEntity;

        Task<int> UpdateAsync<T>(T entity) where T : class, IBaseEntity;

        Task<T> GetAsync<T>(Guid id) where T : class, IBaseEntity;

        Task<List<T>> GetAllAsync<T>() where T : class, IBaseEntity;

    }
}
