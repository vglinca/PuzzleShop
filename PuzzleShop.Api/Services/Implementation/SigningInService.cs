using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using PuzzleShop.Api.Helpers;
using PuzzleShop.Api.Services.Interfaces;
using PuzzleShop.Core.Dtos.Users;
using PuzzleShop.Core.Entities.Auth;
using PuzzleShop.Core.Exceptions;

namespace PuzzleShop.Api.Services.Implementation
{
    public class SigningInService : ISigningInService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public SigningInService(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<string> SignIn(AuthOptions authOptions, UserForAuthDto userDto)
        {
            var user = await _userManager.FindByEmailAsync(userDto.Email);

            if(user == null)
            {
                throw new UnauthorizedException($"Wrong credentials.");
            }

            var passwordResultCheck =
                await _signInManager.PasswordSignInAsync(user, userDto.Password, false,
                    false);

            if (!passwordResultCheck.Succeeded)
            {
                throw new UnauthorizedException("Wrong credentials.");
            }

            var userRoles = await _userManager.GetRolesAsync(user);
            var claims = userRoles
                .Select(role => new Claim(ClaimTypes.Role, role))
                .ToList();
            
            claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
            claims.Add(new Claim(ClaimTypes.Email, user.Email));
            claims.Add(new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}"));

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