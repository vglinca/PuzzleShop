using System.Collections.Generic;
using System.Threading.Tasks;
using PuzzleShop.Entities;

namespace PuzzleShop.Repositories.Interfaces
{
    public interface IRepository<T> where T: BaseEntity
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetOne(long id);
        void AddEntity(T entity);
        void DeleteEntity(T entity);
        Task<bool> ExistsAsync(long id);
        Task<bool> SaveChangesAsync();
    }
}