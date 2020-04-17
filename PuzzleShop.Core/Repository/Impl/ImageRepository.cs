using Microsoft.EntityFrameworkCore;
using PuzzleShop.Core.Repository.Interfaces;
using PuzzleShop.Domain.Entities;
using PuzzleShop.Persistance.DbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleShop.Core.Repository.Impl
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
			_ctx.Set<Image>().RemoveRange(images);
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
