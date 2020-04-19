using PuzzleShop.Core;
using PuzzleShop.Core.Exceptions;
using PuzzleShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleShop.Tests.Repository
{
	public class ManufacturerRepositoryFake : IRepository<Manufacturer>
	{
		private readonly ICollection<Manufacturer> _manufacturers;

		public ManufacturerRepositoryFake()
		{
			_manufacturers = new List<Manufacturer>
			{
				new Manufacturer {Id = 1, Name = "Gan"},
				new Manufacturer {Id = 2, Name = "MoYu"},
				new Manufacturer {Id = 3, Name = "QiYi"},
				new Manufacturer {Id = 4, Name = "Rubics"},
				new Manufacturer {Id = 5, Name = "DaYan"},
			};
		}
		public Task<Manufacturer> AddEntityAsync(Manufacturer entity)
		{
			entity.Id = _manufacturers.Last().Id + 1;
			_manufacturers.Add(entity);
			return Task.FromResult(_manufacturers.Last());
		}

		public Task DeleteEntityAsync(Manufacturer entity)
		{
			if(!_manufacturers.Any(e => e.Id == entity.Id))
			{
				throw new EntityNotFoundException($"Manufacturer not found.");
			}
			_manufacturers.Remove(entity);
			return Task.CompletedTask;
		}

		public void Dispose()
		{
		}

		public async Task<Manufacturer> FindByIdAsync(long id)
		{
			if (!_manufacturers.Any(e => e.Id == id))
			{
				throw new EntityNotFoundException($"Manufacturer not found.");
			}
			return _manufacturers.FirstOrDefault(e => e.Id == id);
		}

		public async Task<IEnumerable<Manufacturer>> GetAllAsync(params object[] parameters)
		{
			return _manufacturers;
		}

		public Task UpdateEntityAsync(Manufacturer entity)
		{
			var manufacturer = _manufacturers.FirstOrDefault(e => e.Id == entity.Id);
			if (manufacturer == null)
			{
				throw new EntityNotFoundException($"Manufacturer not found.");
			}
			manufacturer = entity;
			return Task.FromResult(manufacturer);
		}
	}
}
