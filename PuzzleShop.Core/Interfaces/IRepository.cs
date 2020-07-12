using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PuzzleShop.Core.Domain;
using PuzzleShop.Core.Entities;
using PuzzleShop.Core.Interfaces;
using PuzzleShop.Core.Repository.Interfaces;
// ReSharper disable All

namespace PuzzleShop.Core
{
    public interface IRepository<TEntity> : IEfCoreRepository<TEntity> 
        where TEntity : BaseEntity
    {
        Task<IEnumerable<TEntity>> GetAllAsync(params Expression<Func<TEntity, bool>>[] wherePredicate);
    }
}