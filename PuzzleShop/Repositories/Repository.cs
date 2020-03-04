using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PuzzleShop.DbContexts;
using PuzzleShop.Entities;
using PuzzleShop.Repositories.Interfaces;
// ReSharper disable All

namespace PuzzleShop.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly PuzzleShopDbContext _dbContext;
        protected DbSet<T> _dbSet { get; set; }
        
        public Repository(PuzzleShopDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _dbSet = _dbContext.Set<T>();
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public virtual async Task<T> FindById(long id)
        {
            return await _dbSet.FirstOrDefaultAsync(e => e.Id == id);
        }

        public virtual void AddEntity(T entity)
        {
            _dbSet.Add(entity);
        }

        public async void DeleteEntity(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _dbSet.Remove(entity);
        }

        public async Task<bool> ExistsAsync(long id)
        {
            return await _dbSet.AnyAsync(e => e.Id == id);
        }

        public async Task<bool> CommitAsync()
        {
            return await _dbContext.SaveChangesAsync() >= 0;
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}