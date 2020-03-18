﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PuzzleShop.Api.Dtos.Puzzles;
using PuzzleShop.Core;
using PuzzleShop.Domain.Entities;

namespace PuzzleShop.Api.Controllers
{
    [ApiController]
    [Route("api/puzzles")]
    public class PuzzlesController : ControllerBase
    {
        private readonly IPuzzleRepository _puzzleRepository;
        private readonly IMapper _mapper;

        public PuzzlesController(IMapper mapper, IPuzzleRepository puzzleRepository)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _puzzleRepository = puzzleRepository ?? throw new ArgumentNullException(nameof(puzzleRepository));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PuzzleDto>>> GetPuzzles()
        {
            var puzzles = await _puzzleRepository.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<PuzzleDto>>(puzzles));
        }

        [HttpGet("{puzzleId}")]
        public async Task<ActionResult<PuzzleDto>> GetPuzzle(long puzzleId)
        {
            var puzzle = await _puzzleRepository.FindByIdAsync(puzzleId);
            return Ok(_mapper.Map<PuzzleDto>(puzzle));
        }

        [HttpPost]
        public async Task<ActionResult<PuzzleDto>> AddPuzzle(
            [FromBody] PuzzleForCreationDto puzzleForCreationDto)
        {
            var entityToAdd = _mapper.Map<Puzzle>(puzzleForCreationDto);
            await _puzzleRepository.AddEntityAsync(entityToAdd);
            return CreatedAtAction(nameof(GetPuzzle), new {puzzleId = entityToAdd.Id},
                _mapper.Map<PuzzleDto>(entityToAdd));
        }

        [HttpDelete("{puzzleId}")]
        public async Task<IActionResult> DeletePuzzle(long puzzleId)
        {
            var puzzleToDelete = await _puzzleRepository.FindByIdAsync(puzzleId);
            await _puzzleRepository.DeleteEntityAsync(puzzleToDelete);
            return NoContent();
        }
        
    }
}