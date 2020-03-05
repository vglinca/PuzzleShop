using System.Collections.Generic;
using System.Threading.Tasks;
using PuzzleShop.Domain.Entities;
// ReSharper disable All

namespace PuzzleShop.Core
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        public Task<IEnumerable<T>> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<T> FindById(long id)
        {
            throw new System.NotImplementedException();
        }

        public void AddEntity(T entity)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateEntity(T entity)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteEntity(T entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> ExistsAsync(long id)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> CommitAsync()
        {
            throw new System.NotImplementedException();
        }
        
        public void Dispose()
        {
            throw new System.NotImplementedException();
        }
    }
}