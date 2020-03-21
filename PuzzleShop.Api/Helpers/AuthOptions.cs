using System.Text;
using Microsoft.IdentityModel.Tokens;
// ReSharper disable All

namespace PuzzleShop.Api.Helpers
{
    public class AuthOptions
    {
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public string Secret { get; set; }
        public int TokenLifetime { get; set; }

        public SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Secret));
        }
    }
}