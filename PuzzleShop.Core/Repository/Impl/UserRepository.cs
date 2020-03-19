using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PuzzleShop.Core.Exceptions;
using PuzzleShop.Domain.Entities;
using PuzzleShop.Persistance.DbContext;

namespace PuzzleShop.Core.Repository.Impl
{
    public class UserRepository : IUserRepository
    {

        private readonly PuzzleShopContext _ctx;

        public UserRepository(PuzzleShopContext ctx)
        {
            _ctx = ctx ?? throw new ArgumentNullException(nameof(ctx));
        }
        
        public async Task<User> Authenticate(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                throw new BadRequestException("Password either username cannot be null.");
            }

            var user = await _ctx.Users.SingleOrDefaultAsync(u => u.Username == username);
            if (user == null)
            {
                throw new EntityNotFoundException($"User with username {username} not found.");
            }

            if (!CheckPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            {
                throw new UnauthorizedException($"Password is incorrect.");
            }

            return user;
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _ctx.Users.ToListAsync();
        }

        public async Task<User> GetById(long userId)
        {
            var user = await _ctx.Users.FindAsync(userId);
            if (user == null)
            {
                throw new EntityNotFoundException($"User with Id {userId} not found.");
            }

            return user;
        }

        public async Task<User> Create(User user, string password)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new BadRequestException($"Password cannot be null.");
            }

            if (await _ctx.Users.AnyAsync(u => u.Username == user.Username))
            {
                throw new BadRequestException($"User with username {user.Username} already exists.");
            }

            CreatePasswordHash(password, out var passwordHash, out var passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            _ctx.Users.Add(user);
            await _ctx.SaveChangesAsync();
            return user;
        }
        
        public Task Update(User user, string password = null)
        {
            throw new NotImplementedException();
        }

        public Task Delete(long userId)
        {
            throw new NotImplementedException();
        }
        
        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            if (password == null)
            {
                throw new ArgumentNullException("password");
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");
            }

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private static bool CheckPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            if (password == null)
            {
                throw new ArgumentNullException($"{nameof(password)}");
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");
            }

            if (storedHash.Length != 64)
            {
                throw new ArgumentException("Invalid length of password hash (64 bytes expected).", "passwordHash");
            }

            if (storedSalt.Length != 128)
            {
                throw new ArgumentException("Invalid length of password salt (128 bytes expected).", "passwordHash");
            }

            using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                if (computedHash.Where((t, i) => t != storedHash[i]).Any())
                {
                    return false;
                }
            }

            return true;
        }
    }
}