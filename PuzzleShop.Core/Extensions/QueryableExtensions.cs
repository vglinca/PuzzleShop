﻿using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using PuzzleShop.Core.PaginationModels;
using PuzzleShop.Domain.Entities;
// ReSharper disable All

namespace PuzzleShop.Core.Extensions
{
    public static class QueryableExtensions
    {
        public static async Task<PagedResponse<TDto>> CreatePagedResultAsync<TEntity, TDto>(this IQueryable<TEntity> src,
            PagedRequest request, IMapper mapper) where TEntity : BaseEntity where TDto : class
        {
            var puzzles = src.ProjectTo<TDto>(mapper.ConfigurationProvider);
            puzzles = puzzles.ApplyFilters(request.RequestFilters);
            var itemsCount = await puzzles.CountAsync();
            puzzles = puzzles.Paginate(request.PageNumber, request.PageSize);
            puzzles = puzzles.ApplySort(request.OrderBy, request.OrderByDirection);
            var puzzlesList = await puzzles.ToListAsync();

            return new PagedResponse<TDto>(request.PageNumber, request.PageSize, itemsCount,
                puzzlesList);
        }

        private static IQueryable<T> ApplyFilters<T>(this IQueryable<T> src, RequestFilters filters) where T : class
        {
            var predicate = new StringBuilder();

            for (var i = 0; i < filters.Filters.Count; i++)
            {
                if (i > 0)
                {
                    predicate.Append($" {filters.Operator} ");
                }

                if (!string.IsNullOrWhiteSpace(filters.Filters[i].PropertyName))
                {
                    predicate.Append($"{filters.Filters[i].PropertyName}.{nameof(string.Contains)}(@{i})");
                }
            }

            if (filters.Filters.Count > 0 && 
                filters.Filters.All(f => !string.IsNullOrWhiteSpace(f.PropertyValue)))
            {
                var propertyValues = filters.Filters.Select(f => f.PropertyValue).ToArray();
                src = src.Where(predicate.ToString(), propertyValues);
            }

            return src;
        }

        private static IQueryable<T> Paginate<T>(this IQueryable<T> src, int pageNumber, int pageSize)
            where T : class
        {
            return src.Skip((pageNumber - 1) * pageSize).Take(pageSize);
        }

        public static IQueryable<T> ApplySort<T>(this IQueryable<T> src, string orderBy, string direction)
            where T : class
        {
            if (!string.IsNullOrWhiteSpace(orderBy))
            {
                src = src.OrderBy($"{orderBy} {direction}");
            }

            return src;
        }
    }
}