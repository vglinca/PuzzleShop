using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PuzzleShop.Core.Repository.Interfaces;
using PuzzleShop.Domain.Entities;
// ReSharper disable All

namespace PuzzleShop.Core
{
    public interface IImageRepository<TEntity> : IEfCoreRepository<TEntity> where TEntity : BaseEntity
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
    }
}