﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PuzzleShop.Api.Dtos.PuzzleTypes;
using PuzzleShop.Core;
using PuzzleShop.Domain.Entities;
namespace PuzzleShop.Api.Controllers
{
    [ApiController]
    [Route("api/puzzletypes")]
    public class PuzzleTypeController : ControllerBase
    {
        private readonly IRepository<PuzzleType> _puzzleTypeRepository;
        private readonly IMapper _mapper;

        public PuzzleTypeController(IRepository<PuzzleType> puzzleTypeRepository, IMapper mapper)
        {
            _puzzleTypeRepository = puzzleTypeRepository ?? throw new ArgumentNullException(nameof(puzzleTypeRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PuzzleTypeDto>>> GetPuzzleTypes()
        {
            var puzzleTypeEntities = await _puzzleTypeRepository.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<PuzzleTypeDto>>(puzzleTypeEntities));
        }

        [HttpGet("{puzzleTypeId}")]
        public async Task<ActionResult<PuzzleTypeDto>> GetPuzzleType(long puzzleTypeId)
        {
            var puzzleTypeEntity = await _puzzleTypeRepository.FindByIdAsync(puzzleTypeId);
            if (puzzleTypeEntity == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<PuzzleTypeDto>(puzzleTypeEntity));
        }

        [HttpPost]
        public async Task<ActionResult<PuzzleTypeDto>> AddPuzzleType(
            [FromBody] PuzzleTypeForCreationDto puzzleTypeForCreationDto)
        {
            var newPuzzleType = _mapper.Map<Domain.Entities.PuzzleType>(puzzleTypeForCreationDto);
            await _puzzleTypeRepository.AddEntityAsync(newPuzzleType);
            var dtoToReturn = _mapper.Map<PuzzleTypeDto>(newPuzzleType);
            
            return CreatedAtAction(nameof(GetPuzzleType), 
                new {puzzleTypeId = newPuzzleType.Id}, dtoToReturn);
        }

        [HttpDelete("{puzzleTypeId}")]
        public async Task<IActionResult> DeletePuzzleType(long puzzleTypeId)
        {
            var entityToDel = await _puzzleTypeRepository.FindByIdAsync(puzzleTypeId);
            if (entityToDel == null)
            {
                return NotFound();
            }

            await _puzzleTypeRepository.DeleteEntityAsync(entityToDel);
            return NoContent();
        }
    }
}