using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PuzzleShop.Domain.Entities;
// ReSharper disable All

namespace PuzzleShop.Core
{
    public interface IRepository<TEntity> : IDisposable where TEntity : BaseEntity
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> FindById(long id);
        Task<TEntity> AddEntity(TEntity entity);
        Task UpdateEntity(TEntity entity);
        Task DeleteEntity(TEntity entity);
        Task<bool> ExistsAsync(long id);
        Task<bool> CommitAsync();
    }
}