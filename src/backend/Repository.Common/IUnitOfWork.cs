using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Common
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> AddAsync<T>(T entity) where T : class;

        Task<int> CommitAsync();

        Task<int> DeleteAsync<T>(T entity) where T : class;

        Task<int> DeleteAsync<T>(Guid id) where T : class;

        Task<int> UpdateAsync<T>(T entity) where T : class;

        Task<int> GetAsync<T>(Guid id) where T : class;

        //Task<int> GetAllAsync<T>() where T : class;

    }
}
