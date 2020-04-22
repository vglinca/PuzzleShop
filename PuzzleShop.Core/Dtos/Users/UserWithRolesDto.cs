using System.Collections.Generic;
using System.Security.Cryptography;
// ReSharper disable All

namespace PuzzleShop.Core.Dtos.Users
{
    public class UserWithRolesDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public IList<string> Roles { get; set; } = new List<string>();
    }
}