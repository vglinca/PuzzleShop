using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PuzzleShop.Core.Repository.Interfaces;
using PuzzleShop.Domain.Entities;
// ReSharper disable All

namespace PuzzleShop.Core
{
    public interface IRepository<TEntity> : IEfCoreRepository<TEntity> where TEntity : BaseEntity
    {
        Task<IEnumerable<TEntity>> GetAllAsync(params Expression<Func<TEntity, bool>>[] wherePredicate);
    }
}