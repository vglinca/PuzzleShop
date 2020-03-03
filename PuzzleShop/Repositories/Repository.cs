using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PuzzleShop.DbContexts;
using PuzzleShop.Entities;
using PuzzleShop.Repositories.Interfaces;

namespace PuzzleShop.Repositories
{
    public class Repository<T> : IRepository<T>, IDisposable where T : BaseEntity
    {
        private readonly PuzzleShopDbContext _DbContext;

        public Repository(PuzzleShopDbContext dbContext)
        {
            _DbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public virtual Task<IEnumerable<T>> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public virtual Task<T> GetOne(long id)
        {
            throw new System.NotImplementedException();
        }

        public virtual void AddEntity(T entity)
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

        public async Task<bool> SaveChangesAsync()
        {
            return await _DbContext.SaveChangesAsync() >= 0;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}