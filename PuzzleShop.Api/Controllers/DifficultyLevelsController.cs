using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PuzzleShop.Api.Dtos.DifficultyLevels;
using PuzzleShop.Core;
using PuzzleShop.Domain.Entities;

namespace PuzzleShop.Api.Controllers
{
    [ApiController]
    [Route("api/difficultylevels")]
    public class DifficultyLevelController : ControllerBase
    {
        private readonly IRepository<DifficultyLevel> _difflvlRepository;
        private readonly IMapper _mapper;

        public DifficultyLevelController(IRepository<DifficultyLevel> difflvlRepository, IMapper mapper)
        {
            _difflvlRepository = difflvlRepository ?? throw new ArgumentNullException(nameof(difflvlRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DifficultyLevelDto>>> GetDifficultyLevels()
        {
            var entities = await _difflvlRepository.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<DifficultyLevelDto>>(entities));
        }
    }
}