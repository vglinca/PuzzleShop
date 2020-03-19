// ReSharper disable All

using System.Collections;
using System.Collections.Generic;

namespace PuzzleShop.Domain.Entities
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public int? Age { get; set; }
        public string Phone { get; set; }
        public string Token { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public long RoleId { get; set; }
        public UserRole UserRole { get; set; }
    }
}