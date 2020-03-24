using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using PuzzleShop.Api.Helpers;
using PuzzleShop.Api.Services.Interfaces;
using PuzzleShop.Domain.Entities.Auth;

namespace PuzzleShop.Api.Services.Impl
{
    public class SigningInService : ISigningInService
    {
        private readonly UserManager<User> _userManager;

        public SigningInService(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<string> SignIn(AuthOptions authOptions, string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            var userRoles = await _userManager.GetRolesAsync(user);
            var claims = userRoles
                .Select(role => new Claim(ClaimTypes.Role, role))
                .ToList();

            var signInCredentials = new SigningCredentials(authOptions.GetSymmetricSecurityKey(), 
                SecurityAlgorithms.HmacSha256);
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {    
                Subject = new ClaimsIdentity(claims),
                Issuer = authOptions.Issuer,
                Audience = authOptions.Audience,
                Expires = DateTime.Now.AddHours(authOptions.TokenLifetime),
                SigningCredentials = signInCredentials
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}