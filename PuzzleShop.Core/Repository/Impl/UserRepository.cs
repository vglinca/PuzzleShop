// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using Microsoft.EntityFrameworkCore;
// using PuzzleShop.Core.Exceptions;
// using PuzzleShop.Domain.Entities;
// using PuzzleShop.Persistance.DbContext;
//
// namespace PuzzleShop.Core.Repository.Impl
// {
//     public class UserRepository : IUserRepository
//     {
//         private readonly PuzzleShopContext _ctx;
//
//         public UserRepository(PuzzleShopContext ctx)
//         {
//             _ctx = ctx ?? throw new ArgumentNullException(nameof(ctx));
//         }
//         
//         public async Task<User> AuthenticateAsync(string username, string password)
//         {
//             if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
//             {
//                 throw new BadRequestException("Password either username cannot be null.");
//             }
//
//             var user = await _ctx.Users
//                 .Include(u => u.UserRole)
//                 .SingleOrDefaultAsync(u => u.Username == username);
//             
//             if (user == null)
//             {
//                 throw new EntityNotFoundException($"Username or password is incorrect.");
//             }
//
//             if (!CheckPasswordHash(password, user.PasswordHash, user.PasswordSalt))
//             {
//                 throw new AuthenticationFailedException($"Password is wrong.");
//             }
//
//             return user;
//         }
//
//         public async Task<IEnumerable<User>> GetAllUsersAsync()
//         {
//             return await _ctx.Users
//                 .Include(u => u.UserRole)
//                 .ToListAsync();
//         }
//
//         public async Task<User> GetByIdAsync(long userId)
//         {
//             var user = await _ctx.Users
//                 .Include(u => u.UserRole)
//                 .FirstOrDefaultAsync(u => u.Id == userId);
//             
//             if (user == null)
//             {
//                 throw new EntityNotFoundException($"User with Id {userId} not found.");
//             }
//
//             return user;
//         }
//
//         public async Task<User> RegisterAsync(User user, string password)
//         {
//             if (string.IsNullOrWhiteSpace(password))
//             {
//                 throw new BadRequestException("Password cannot be null.");
//             }
//
//             if (await _ctx.Users.AnyAsync(u => u.Username == user.Username))
//             {
//                 throw new BadRequestException($"User with username {user.Username} already exists.");
//             }
//
//             CreatePasswordHash(password, out var passwordHash, out var passwordSalt);
//
//             user.PasswordHash = passwordHash;
//             user.PasswordSalt = passwordSalt;
//
//             _ctx.Users.Add(user);
//             await _ctx.SaveChangesAsync();
//             return user;
//         }
//         
//         public async Task UpdateAsync(User user, string password = null)
//         {
//             var userToUpdate = await _ctx.Users.FindAsync(user.Id);
//             if (user == null)
//             {
//                 throw new EntityNotFoundException($"User with Id {user.Id} not found.");
//             }
//
//             //update username if provided
//             if (!string.IsNullOrWhiteSpace(user.Username) && user.Username != userToUpdate.Username)
//             {
//                 if (await _ctx.Users.AnyAsync(u => u.Username == user.Username))
//                 {
//                     throw new BadRequestException($"User with username {user.Username} already exists.");
//                 }
//
//                 userToUpdate.Username = user.Username;
//             }
//             //update fName and lName, if provided
//             if (!string.IsNullOrWhiteSpace(user.FirstName) && user.FirstName != userToUpdate.FirstName)
//             {
//                 userToUpdate.FirstName = user.FirstName;
//             }
//             if (!string.IsNullOrWhiteSpace(user.LastName) && user.LastName != userToUpdate.LastName)
//             {
//                 userToUpdate.LastName = user.LastName;
//             }
//
//             if (! string.IsNullOrWhiteSpace(password))
//             {
//                 CreatePasswordHash(password, out var passwordHash, out var passwordSalt);
//                 userToUpdate.PasswordHash = passwordHash;
//                 userToUpdate.PasswordSalt = passwordSalt;
//             }
//
//             _ctx.Users.Update(userToUpdate);
//             await _ctx.SaveChangesAsync();
//         }
//
//         public async Task DeleteAsync(long userId)
//         {
//             var userToDelete = await _ctx.Users.FindAsync(userId);
//             if (userToDelete == null)
//             {
//                 throw new EntityNotFoundException($"User with Id {userId} not found.");
//             }
//
//             _ctx.Users.Remove(userToDelete);
//             await _ctx.SaveChangesAsync();
//         }
//
//         public async Task AddTokenAsync(long userId, string token)
//         {
//             var usr = await _ctx.Users.FindAsync(userId);
//             if (string.IsNullOrWhiteSpace(usr.Token) || usr.Token != token)
//             {
//                 usr.Token = token;
//                 _ctx.Users.Update(usr);
//             }
//             await _ctx.SaveChangesAsync();
//         }
//
//         private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
//         {
//             if (password == null || string.IsNullOrWhiteSpace(password))
//             {
//                 throw new BadRequestException("Password cannot be null.");
//             }
//
//             using (var hmac = new System.Security.Cryptography.HMACSHA512())
//             {
//                 passwordSalt = hmac.Key;
//                 passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
//             }
//         }
//
//         private static bool CheckPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
//         {
//             if (password == null || string.IsNullOrWhiteSpace(password))
//             {
//                 throw new ArgumentNullException($"{nameof(password)}");
//             }
//
//             if (storedHash.Length != 64)
//             {
//                 throw new ArgumentException("Invalid length of password hash (64 bytes expected).", nameof(storedHash));
//             }
//
//             if (storedSalt.Length != 128)
//             {
//                 throw new ArgumentException("Invalid length of password salt (128 bytes expected).", nameof(storedSalt));
//             }
//
//             using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
//             {
//                 var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
//                 if (computedHash.Where((b, i) => b != storedHash[i]).Any())
//                 {
//                     return false;
//                 }
//             }
//
//             return true;
//         }
//     }
// }