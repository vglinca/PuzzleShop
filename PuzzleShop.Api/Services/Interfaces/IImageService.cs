using PuzzleShop.Core.Dtos.Images;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PuzzleShop.Api.Services.Interfaces
{
	public interface IImageService
	{
		Task<IEnumerable<ImageDto>> GetImagesAsync(long puzzleId);
		Task AddImageAsync(long puzzleId, ImageForUpdateDto model);
		Task DeleteImagesAsync(long puzzleId, IEnumerable<long> ids);
	}
}
