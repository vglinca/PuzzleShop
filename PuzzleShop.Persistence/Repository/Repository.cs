using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PuzzleShop.Core;
using PuzzleShop.Core.Domain;
using PuzzleShop.Core.Entities;
using PuzzleShop.Core.Exceptions;
using PuzzleShop.Persistance.DbContext;

// ReSharper disable All

namespace PuzzleShop.Persistance.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly PuzzleShopContext _ctx;
        private readonly ILogger<Repository<TEntity>> _logger;
        public Repository(PuzzleShopContext ctx, ILogger<Repository<TEntity>> logger)
        {
            _ctx = ctx;
            _logger = logger;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(params Expression<Func<TEntity, bool>>[] wherePredicate)
        {
            IQueryable<TEntity> entities = _ctx.Set<TEntity>();
            foreach (var predicate in wherePredicate)
            {
                entities = entities.Where(predicate);
            }
            
            return await entities.ToListAsync();
        }

        public async Task<TEntity> FindByIdAsync(long id)
        {
            var entity = await _ctx.FindAsync<TEntity>(id);
            if (entity == null)
            {
                _logger.LogError($"{typeof(TEntity).ToString().Split('.').Last()} with id {id} not found.");
                throw EntityNotFoundException.OfType<TEntity>(id);
            }

            return entity;
        }

        public async Task<TEntity> AddEntityAsync(TEntity entity)
        {
            if (entity == null)
            {
                _logger.LogError($"Bad request. {typeof(TEntity).ToString().Split('.').Last()} not provided.");
                throw new BadRequestException($"{nameof(entity)} is null.");
            }
            _ctx.Set<TEntity>().Add(entity);
            await _ctx.SaveChangesAsync();
            return entity;
        }

        public async Task UpdateEntityAsync(TEntity entity)
        {
            if (entity == null)
            {
                _logger.LogError($"Bad request. {typeof(TEntity).ToString().Split('.').Last()} not provided.");
                throw new BadRequestException($"{nameof(entity)} is null.");
            }

            _ctx.Entry(entity).State = EntityState.Modified;
            await _ctx.SaveChangesAsync();
        }

        public async Task DeleteEntityAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new BadRequestException($"{nameof(entity)} is null.");
            }

            var entityToDel = _ctx.FindAsync<TEntity>(entity.Id);
            if (entityToDel == null)
            {
                _logger.LogError($"{typeof(TEntity).ToString().Split('.').Last()} with id {entity.Id} not found.");
                throw new EntityNotFoundException(
                    $"{typeof(TEntity).ToString().Split('.').Last()} with Id {entity.Id} not found.");
            }
            _ctx.Set<TEntity>().Remove(entity);
            await _ctx.SaveChangesAsync();
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