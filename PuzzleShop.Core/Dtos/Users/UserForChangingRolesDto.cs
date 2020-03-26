using System.Collections.Generic;
using PuzzleShop.Domain.Entities.Auth;
// ReSharper disable All

namespace PuzzleShop.Core.Dtos.Users
{
    public class UserForChangingRolesDto
    {
        public long UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public List<Role> AllRoles { get; set; } = new List<Role>();
        public List<Role> UserRoles { get; set; } = new List<Role>();
    }
}