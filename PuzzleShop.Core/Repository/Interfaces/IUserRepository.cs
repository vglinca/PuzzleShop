using System.Collections.Generic;
using System.Threading.Tasks;
using PuzzleShop.Domain.Entities;
// ReSharper disable All

namespace PuzzleShop.Core
{
    public interface IUserRepository
    {
        Task<User> Authenticate(string username, string password);
        Task<IEnumerable<User>> GetAllUsers();
        Task<User> GetById(long userId);
        Task<User> Create(User user, string password);
        Task Update(User user, string password = null);
        Task Delete(long userId);
    }
}