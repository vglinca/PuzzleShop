using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PuzzleShop.Core.Repository.Interfaces;
using PuzzleShop.Core.ResourceParameters;
using PuzzleShop.Domain.Entities;
// ReSharper disable All

namespace PuzzleShop.Core
{
    public interface IRepository<TEntity> : IEfCoreRepository<TEntity> where TEntity : BaseEntity
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
    }
}