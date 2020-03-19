using System.Collections.Generic;
// ReSharper disable All

namespace PuzzleShop.Domain.Entities
{
    public class UserRole : BaseEntity
    {
        public string Title { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}