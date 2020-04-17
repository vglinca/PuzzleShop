﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PuzzleShop.Core;
using PuzzleShop.Core.Dtos.PuzzleTypes;
using PuzzleShop.Domain.Entities;
namespace PuzzleShop.Api.Controllers
{
    [ApiController]
    [AllowAnonymous]
    [Route("api/[controller]")]
    public class PuzzleTypesController : ControllerBase
    {
        private readonly IImageRepository<PuzzleType> _puzzleTypeRepository;
        private readonly IMapper _mapper;

        public PuzzleTypesController(IImageRepository<PuzzleType> puzzleTypeRepository, IMapper mapper)
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
            return Ok(_mapper.Map<PuzzleTypeDto>(puzzleTypeEntity));
        }

        [Authorize(Roles = "admin")]
        [Authorize(Roles = "moderator")]
        [HttpPost]
        public async Task<ActionResult<PuzzleTypeDto>> AddPuzzleType(
            [FromBody] PuzzleTypeForCreationDto puzzleTypeForCreationDto)
        {
            var newPuzzleType = _mapper.Map<Domain.Entities.PuzzleType>(puzzleTypeForCreationDto);
            await _puzzleTypeRepository.AddEntityAsync(newPuzzleType);
            
            return CreatedAtAction(nameof(GetPuzzleType), new {puzzleTypeId = newPuzzleType.Id}, 
                _mapper.Map<PuzzleTypeDto>(newPuzzleType));
        }

        [HttpPut("{puzzleTypeId}")]
        public async Task<IActionResult> UpdatePuzzleType(long puzzleTypeId,
            [FromBody] PuzzleTypeForCreationDto puzzleTypeForUpdateDto)
        {
            var puzzleTypeFromRepo = await _puzzleTypeRepository.FindByIdAsync(puzzleTypeId);
            _mapper.Map(puzzleTypeForUpdateDto, puzzleTypeFromRepo);
            await _puzzleTypeRepository.UpdateEntityAsync(puzzleTypeFromRepo);
            return Ok();
        }

        [Authorize(Roles = "admin")]
        [Authorize(Roles = "moderator")]
        [HttpDelete("{puzzleTypeId}")]
        public async Task<IActionResult> DeletePuzzleType(long puzzleTypeId)
        {
            var entityToDel = await _puzzleTypeRepository.FindByIdAsync(puzzleTypeId);
            await _puzzleTypeRepository.DeleteEntityAsync(entityToDel);
            
            return NoContent();
        }
    }
}