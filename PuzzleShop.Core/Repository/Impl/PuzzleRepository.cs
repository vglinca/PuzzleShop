using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PuzzleShop.Core.Dtos.Puzzles;
using PuzzleShop.Core.Exceptions;
using PuzzleShop.Core.Extensions;
using PuzzleShop.Core.Helpers;
using PuzzleShop.Core.PaginationModels;
using PuzzleShop.Core.Repository.Interfaces;
using PuzzleShop.Domain.Entities;
using PuzzleShop.Persistance.DbContext;

namespace PuzzleShop.Core.Repository.Impl
{
    public sealed class PuzzleRepository : IPuzzleRepository
    {
        private readonly PuzzleShopContext _ctx;

        public PuzzleRepository(PuzzleShopContext ctx)
        {
            _ctx = ctx ?? throw new ArgumentNullException(nameof(ctx));
        }

        public async Task<PagedResponse<PuzzleDto>> GetAllAsync(PagedRequest pagedRequest, IMapper mapper)
        {
            var puzzles = _ctx.Puzzles;
            return await puzzles.CreatePagedResultAsync<Puzzle, PuzzleDto>(pagedRequest, mapper);
        }

        public async Task<Puzzle> FindByIdAsync(long id)
        {
            var puzzle = await _ctx.Puzzles
                .Where(p => p.Id == id)
                .FirstOrDefaultAsync();

            if (puzzle == null)
            {
                throw new EntityNotFoundException($"Puzzle with Id {id} not found.");
            }

            return puzzle;
        }

        public async Task<Puzzle> AddEntityAsync(Puzzle puzzle)
        {
            if (puzzle == null)
            {
                throw new BadRequestException($"{nameof(puzzle)} is null.");
            }

            var manufacturer = await _ctx.Manufacturers
                .FirstOrDefaultAsync(m => m.Id == puzzle.ManufacturerId);
            var color = await _ctx.Colors
                .FirstOrDefaultAsync(c => c.Id == puzzle.ColorId);
            var puzzleType = await _ctx.PuzzleTypes
                .FirstOrDefaultAsync(pt => pt.Id == puzzle.PuzzleTypeId);
            var materialType = await _ctx.MaterialTypes
                .FirstOrDefaultAsync(mt => mt.Id == puzzle.MaterialTypeId);
            var difficultyLevel = await _ctx.DifficultyLevels
                .FirstOrDefaultAsync(l => l.Id == (long) puzzle.DifficultyLevelId);

            foreach (var image in puzzle.Images)
            {
                image.Title = puzzle.Name;
                image.FileName += Guid.NewGuid();//???
                image.PuzzleId = puzzle.Id;
            }
            await _ctx.Images.AddRangeAsync(puzzle.Images);
            
            puzzle.Manufacturer = manufacturer;
            puzzle.Color = color;
            puzzle.PuzzleType = puzzleType;
            puzzle.MaterialType = materialType;
            puzzle.DifficultyLevel = difficultyLevel;

            _ctx.Puzzles.Add(puzzle);
            await _ctx.SaveChangesAsync();
            return puzzle;
        }

        public async Task UpdateEntityAsync(Puzzle puzzle)
        {
            if (puzzle == null)
            {
                throw new BadRequestException($"{nameof(puzzle)} is null.");
            }

            _ctx.Entry(puzzle).State = EntityState.Modified;
            await _ctx.SaveChangesAsync();
        }

        public async Task DeleteEntityAsync(Puzzle entity)
        {
            if (entity == null)
            {
                throw new BadRequestException($"{nameof(entity)} is null.");
            }
            
            var puzzleToDelete = await _ctx.Puzzles.FirstOrDefaultAsync(p => p.Id == entity.Id);
            if (puzzleToDelete == null)
            {
                throw new EntityNotFoundException($"Puzzle with Id {entity.Id} not found.");
            }

            _ctx.Puzzles.Remove(puzzleToDelete);
            await _ctx.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
            {
            }
        }
    }
}