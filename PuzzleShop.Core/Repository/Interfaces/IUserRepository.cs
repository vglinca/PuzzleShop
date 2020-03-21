// using System.Collections.Generic;
// using System.Threading.Tasks;
// using PuzzleShop.Domain.Entities;
// // ReSharper disable All
//
// namespace PuzzleShop.Core
// {
//     public interface IUserRepository
//     {
//         Task<User> AuthenticateAsync(string username, string password);
//         Task<IEnumerable<User>> GetAllUsersAsync();
//         Task<User> GetByIdAsync(long userId);
//         Task<User> RegisterAsync(User user, string password);
//         Task UpdateAsync(User user, string password = null);
//         Task DeleteAsync(long userId);
//         Task AddTokenAsync(long userId, string token);
//     }
// }