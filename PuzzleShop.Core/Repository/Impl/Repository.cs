using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PuzzleShop.Core.Exceptions;
using PuzzleShop.Domain.Entities;
using PuzzleShop.Persistance.DbContext;

// ReSharper disable All

namespace PuzzleShop.Core
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly PuzzleShopContext _ctx;

        public Repository(PuzzleShopContext ctx)
        {
            _ctx = ctx ?? throw new ArgumentNullException(nameof(ctx));
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _ctx.Set<TEntity>().ToListAsync();
        }

        public virtual async Task<TEntity> FindByIdAsync(long id)
        {
            var entity = //await _ctx.Set<TEntity>().FirstOrDefaultAsync(e => e.Id == id);
                await _ctx.FindAsync<TEntity>(id);
            if (entity == null)
            {
                throw new EntityNotFoundException(
                    $"{typeof(TEntity).ToString().Split('.').Last()} with Id {id} not found.");
            }
            return entity;
        }

        public virtual async Task<TEntity> AddEntityAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new BadRequestException($"{nameof(entity)} is null.");
                //throw new ArgumentNullException(nameof(entity));
            }
            _ctx.Set<TEntity>().Add(entity);
            await _ctx.SaveChangesAsync();
            return entity;
        }

        public virtual async Task UpdateEntityAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new BadRequestException($"{nameof(entity)} is null.");
                //throw new ArgumentNullException(nameof(entity));
            }

            _ctx.Entry(entity).State = EntityState.Modified;
            await _ctx.SaveChangesAsync();
        }

        public virtual async Task DeleteEntityAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new BadRequestException($"{nameof(entity)} is null.");
                //throw new ArgumentNullException(nameof(entity));
            }

            var entityToDel = _ctx.FindAsync<TEntity>(entity.Id);
            if (entityToDel == null)
            {
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