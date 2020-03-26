using System;
using System.Threading.Tasks;
using PuzzleShop.Domain.Entities;

namespace PuzzleShop.Core.Repository.Interfaces
{
    public interface IEfCoreRepository<TEntity> : IDisposable where TEntity : BaseEntity
    {
        Task<TEntity> FindByIdAsync(long id);
        Task<TEntity> AddEntityAsync(TEntity entity);
        Task UpdateEntityAsync(TEntity entity);
        Task DeleteEntityAsync(TEntity entity);
    }
}