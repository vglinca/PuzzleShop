using PuzzleShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleShop.Core.Repository.Interfaces
{
	public interface IImageRepository : IDisposable
	{
		Task<IEnumerable<Image>> GetImagesAsync(long puzzleId);
		Task AddImagesAsync(List<Image> images);
		Task DeleteImagesAsync(long puzzleId, IEnumerable<long> ids);
	}
}
