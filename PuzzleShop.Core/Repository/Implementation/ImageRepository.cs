using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PuzzleShop.Core.Repository.Interfaces;
using PuzzleShop.Domain.Entities;
using PuzzleShop.Persistance.DbContext;

namespace PuzzleShop.Core.Repository.Implementation
{
	public class ImageRepository : IImageRepository
	{
		private readonly PuzzleShopContext _ctx;

		public ImageRepository(PuzzleShopContext ctx)
		{
			_ctx = ctx;
		}

		public async Task AddImagesAsync(List<Image> images)
		{
			await _ctx.Set<Image>().AddRangeAsync(images);
			await _ctx.SaveChangesAsync();
		}

		public async Task DeleteImagesAsync(long puzzleId, IEnumerable<long> ids)
		{
			var images = _ctx.Set<Image>().Where(i => i.PuzzleId == puzzleId);
			var imagesToRemove = new List<Image>();
			foreach (var img in images)
			{
				if (ids.Contains(img.Id))
				{
					imagesToRemove.Add(img);
				}
			}
			_ctx.Set<Image>().RemoveRange(imagesToRemove);
			await _ctx.SaveChangesAsync();
		}
		public async Task<IEnumerable<Image>> GetImagesAsync(long puzzleId)
		{
			return await _ctx.Set<Image>().Where(i => i.PuzzleId == puzzleId).ToListAsync();
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (disposing)
			{
			}
		}
	}
}
