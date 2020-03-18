using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PuzzleShop.Core.Exceptions;
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

        public async Task<IEnumerable<Puzzle>> GetAllAsync()
        {
            return await _ctx.Puzzles
                .Include(p => p.Manufacturer)
                .Include(p => p.Color)
                .Include(p => p.PuzzleType)
                .Include(p => p.MaterialType)
                .Include(p => p.DifficultyLevel)
                .Include(p => p.Images)
                .ToListAsync();
        }

        public async Task<Puzzle> FindByIdAsync(long id)
        {
            var puzzle = await _ctx.Puzzles
                .Where(p => p.Id == id)
                .Include(p => p.Manufacturer)
                .Include(p => p.Color)
                .Include(p => p.PuzzleType)
                .Include(p => p.MaterialType)
                .Include(p => p.DifficultyLevel)
                .Include(p => p.Images.OrderBy(i => i.Title))
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
            var difficultyLevel = await _ctx.Levels
                .FirstOrDefaultAsync(l => l.Id == puzzle.DifficultyLevelId);

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

        public async Task<bool> ExistsAsync(long id)
        {
            return await _ctx.Puzzles.AnyAsync(p => p.Id == id);
        }

        public async Task<bool> CommitAsync()
        {
            return await _ctx.SaveChangesAsync() >= 0;
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