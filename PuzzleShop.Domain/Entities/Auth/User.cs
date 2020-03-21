using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace PuzzleShop.Domain.Entities.Auth
{
    public class User : IdentityUser<long>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public int? Age { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}