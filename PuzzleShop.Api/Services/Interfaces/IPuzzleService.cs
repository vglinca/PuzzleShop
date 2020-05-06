using PuzzleShop.Core.Dtos.Puzzles;
using PuzzleShop.Core.PaginationModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PuzzleShop.Api.Services.Interfaces
{
	public interface IPuzzleService
	{
		Task<PagedResponse<PuzzleTableRowDto>> GetPuzzlesAsync(PagedRequest request);
		Task<TDto> GetPuzzleAsync<TDto>(long puzzleId) where TDto : PuzzleBaseDto;
		Task<PuzzleDto> AddPuzzleAsync(PuzzleForCreationDto puzzle);
		Task UpdatePuzzleAsync(long puzzleId, PuzzleForUpdateDto puzzle);
		Task DeletePuzzleAsync(long puzzleId);
	}
}
