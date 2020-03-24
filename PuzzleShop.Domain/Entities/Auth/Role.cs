using Microsoft.AspNetCore.Identity;

namespace PuzzleShop.Domain.Entities.Auth
{
    public class Role : IdentityRole<long>
    {
        public Role()
        {
        }

        public Role(string name) : base(name)
        {
        }
    }
}