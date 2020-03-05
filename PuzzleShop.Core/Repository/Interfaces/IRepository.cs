using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PuzzleShop.Domain.Entities;
// ReSharper disable All

namespace PuzzleShop.Core
{
    public interface IRepository<T> : IDisposable where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> FindById(long id);
        void AddEntity(T entity);
        void UpdateEntity(T entity);
        void DeleteEntity(T entity);
        Task<bool> ExistsAsync(long id);
        Task<bool> CommitAsync();
    }
}