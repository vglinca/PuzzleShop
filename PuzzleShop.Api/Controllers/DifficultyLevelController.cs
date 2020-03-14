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
        public async Task<ActionResult<IEnumerable<DifficultyLevelDto>>> GetDiffLevels()
        {
            var entities = await _difflvlRepository.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<DifficultyLevelDto>>(entities));
        }

        [HttpGet("{levelId}")]
        public async Task<ActionResult<DifficultyLevelDto>> GetDiffLevel(long levelId)
        {
            var lvlEntity = await _difflvlRepository.FindById(levelId);
            if (lvlEntity == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<DifficultyLevelDto>(lvlEntity));
        }

        [HttpPost]
        public async Task<ActionResult<DifficultyLevelDto>> AddLevel([FromBody] DifficultyLevelForCreationDto incomingDto)
        {
            var lvlEntity = _mapper.Map<DifficultyLevel>(incomingDto);
            await _difflvlRepository.AddEntity(lvlEntity);

            return CreatedAtAction(nameof(GetDiffLevel), new {levelId = lvlEntity.Id},
                _mapper.Map<DifficultyLevelDto>(lvlEntity));
        }

        [HttpPut("{levelId}")]
        public async Task<IActionResult> UpdateLevel(long levelId, [FromBody] DifficultyLevelForCreationDto incomingDto)
        {
            var lvlEntity = await _difflvlRepository.FindById(levelId);
            if (lvlEntity == null)
            {
                return NotFound();
            }

            _mapper.Map(incomingDto, lvlEntity);
            await _difflvlRepository.UpdateEntity(lvlEntity);
            return NoContent();
        }

        [HttpDelete("{levelId}")]
        public async Task<IActionResult> DeleteLevel(long levelId)
        {
            var lvlEntity = await _difflvlRepository.FindById(levelId);
            if (lvlEntity == null)
            {
                return NotFound();
            }

            await _difflvlRepository.DeleteEntity(lvlEntity);
            return NoContent();
        }
        
    }
}