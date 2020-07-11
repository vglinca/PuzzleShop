using PuzzleShop.Core.Dtos.Reviews;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PuzzleShop.Api.Services.Interfaces
{
	public interface IPuzzleReviewService
	{
		Task<IEnumerable<ReviewDto>> GetAllReviewsAsync(long puzzleId);
		Task AddReviewAsync(long puzzleId, ReviewForCreationDto review);
	}
}
