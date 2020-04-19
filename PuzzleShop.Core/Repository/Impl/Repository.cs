using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PuzzleShop.Core.Exceptions;
using PuzzleShop.Core.Extensions;
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

        public async Task<IEnumerable<TEntity>> GetAllAsync(params object[] parameters)
        {
            var entities = _ctx.Set<TEntity>().AsQueryable();
            if(parameters.Length > 0)
            {
                entities = entities.Filter(parameters);
            }
            return await entities.ToListAsync();
        }

        public async Task<TEntity> FindByIdAsync(long id)
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

        public async Task<TEntity> AddEntityAsync(TEntity entity)
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

        public async Task UpdateEntityAsync(TEntity entity)
        {
            if (entity == null)
            {
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