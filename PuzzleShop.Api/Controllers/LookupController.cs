using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PuzzleShop.Core;
using PuzzleShop.Core.Dtos.DifficultyLevels;
using PuzzleShop.Core.Dtos.Roles;
using PuzzleShop.Domain.Entities;
using PuzzleShop.Domain.Entities.Auth;

namespace PuzzleShop.Api.Controllers
{
    [Authorize(Roles = "admin")]
    [ApiController]
    [Route("api/[controller]")]
    public class LookupController : ControllerBase
    {
        private readonly IRepository<DifficultyLevel> _difflvlRepository;
        private readonly RoleManager<Role> _roleManager;
        private readonly IMapper _mapper;

        public LookupController(IRepository<DifficultyLevel> difflvlRepository, IMapper mapper, RoleManager<Role> roleManager)
        {
            _difflvlRepository = difflvlRepository;
            _mapper = mapper;
            _roleManager = roleManager;
        }
        
        [HttpGet("difficultylevels")]
        public async Task<ActionResult<IEnumerable<DifficultyLevelDto>>> GetDifficultyLevels()
        {
            var entities = await _difflvlRepository.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<DifficultyLevelDto>>(entities));
        }

        [HttpGet("roles")]
        public async Task<ActionResult<IEnumerable<RoleDto>>> GetRoles()
        {
            var roles = await _roleManager.Roles.ToListAsync();
            return Ok(_mapper.Map<IEnumerable<RoleDto>>(roles));
        }
    }
}