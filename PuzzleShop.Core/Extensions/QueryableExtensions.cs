using System.Linq;
using System.Linq.Dynamic.Core;
using System.Reflection;
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
            PagedRequest request, IMapper mapper) where TEntity : class where TDto : class
        {
            var entities = src.ProjectTo<TDto>(mapper.ConfigurationProvider);
            entities = entities.ApplyFilters(request.RequestFilters);
            var itemsCount = await entities.CountAsync();
            entities = entities.ApplySort(request.OrderBy, request.OrderByDirection);
            entities = entities.Paginate(request.PageNumber, request.PageSize);
            var puzzlesList = await entities.ToListAsync();

            return new PagedResponse<TDto>(request.PageNumber, request.PageSize, itemsCount, puzzlesList);
        }

        private static IQueryable<T> ApplyFilters<T>(this IQueryable<T> src, RequestFilters filters) where T : class
        {
            var predicate = new StringBuilder();
            var firstAppended = false;

            for (var i = 0; i < filters.Filters.Count; i++)
            {
                if (i > 0)
                {
                    predicate.Append($" {filters.Operator} ");
                }
                //if (!string.IsNullOrWhiteSpace(filters.Filters[i].PropertyName) && !string.IsNullOrWhiteSpace(filters.Filters[i].PropertyValue))
                //{



                //    if (!firstAppended)
                //    {
                //        firstAppended = true;
                //    }
                //}
                predicate.Append($"{filters.Filters[i].PropertyName}.{nameof(string.Contains)}(@{i})");
            }

            if (filters.Filters.Any()
                //filters.Filters.All(f => !string.IsNullOrWhiteSpace(f.PropertyValue))
                )
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

        private static IQueryable<T> ApplySort<T>(this IQueryable<T> src, string orderBy, string direction)
            where T : class
        {
            if (!string.IsNullOrWhiteSpace(orderBy))
            {
                var propertyInfo = typeof(T).GetProperty(orderBy, BindingFlags.IgnoreCase | BindingFlags.Public |
                                                                  BindingFlags.Instance);
                src = src.OrderBy($"{propertyInfo.Name} {direction}");
            }
             
            return src;
        }

        public static IQueryable<T> Filter<T>(this IQueryable<T> src, params object[] parameters) where T : class
        {
            if(parameters.Length == 0)
            {
                return src;
            }
            var query = $"{parameters[0]}.{nameof(string.Contains)}(@0)";
            src = src.Where(query, parameters[1]);
            return src;
        }
    }
}