using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using PuzzleShop.Core.Entities;

namespace PuzzleShop.Core.Domain.Auth
{
    public class User : IdentityUser<long>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public DateTime? BirthDate { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}