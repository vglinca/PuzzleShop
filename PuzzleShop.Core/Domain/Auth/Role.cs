using Microsoft.AspNetCore.Identity;

namespace PuzzleShop.Core.Domain.Auth
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