using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using PuzzleShop.Api.Dtos.Users;
using PuzzleShop.Api.Helpers;
using PuzzleShop.Api.Services.Interfaces;
using PuzzleShop.Domain.Entities.Auth;

namespace PuzzleShop.Api.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthOptions _authOptions;
        private readonly IMapper _mapper;
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly ISigningInService _signingInService;

        public AuthController(IOptions<AuthOptions> authOptions, IMapper mapper, 
            SignInManager<User> signInManager, UserManager<User> userManager, ISigningInService signingInService)
        {
            _mapper = mapper;
            _signInManager = signInManager;
            _userManager = userManager;
            _signingInService = signingInService;
            _authOptions = authOptions.Value;
        }
    
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserForRegistrationDto userForRegistrationDto)
        {
            var user = _mapper.Map<User>(userForRegistrationDto);
            await _userManager.CreateAsync(user, userForRegistrationDto.Password);
            await _userManager.AddToRoleAsync(user, "user");
            return Ok();
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] UserForAuthDto userForAuthDto)
        {
            var passwordResultCheck =
                await _signInManager.PasswordSignInAsync(userForAuthDto.UserName, userForAuthDto.Password, false,
                    false);

            if (!passwordResultCheck.Succeeded) return Unauthorized();
            
            var jwtToken = await _signingInService.SignIn(_authOptions, userForAuthDto.UserName);
            HttpContext.Session.SetString("JWToken", jwtToken);
                
            return Ok(new {AccessToken = jwtToken});
        }
        
        [Authorize]
        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            HttpContext.Session.Clear();
            return Ok();
        }
    }
}