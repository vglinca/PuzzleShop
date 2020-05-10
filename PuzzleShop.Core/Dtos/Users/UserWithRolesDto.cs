using PuzzleShop.Core.Dtos.Roles;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
// ReSharper disable All

namespace PuzzleShop.Core.Dtos.Users
{
    public class UserWithRolesDto
    {
        public long Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime? Age { get; set; }
        public IList<string> Roles { get; set; } = new List<string>();
    }
}