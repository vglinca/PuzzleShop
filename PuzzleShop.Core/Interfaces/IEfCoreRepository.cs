using System;
using System.Threading.Tasks;
using PuzzleShop.Core.Domain;
using PuzzleShop.Core.Entities;

namespace PuzzleShop.Core.Interfaces
{
    public interface IEfCoreRepository<TEntity> : IDisposable 
        where TEntity : BaseEntity
    {
        Task<TEntity> FindByIdAsync(long id);
        Task<TEntity> AddEntityAsync(TEntity entity);
        Task UpdateEntityAsync(TEntity entity);
        Task DeleteEntityAsync(TEntity entity);
    }
}