using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

// ReSharper disable All

namespace PuzzleShop.Core.Helpers
{
    public class PagedList<T> : List<T>
    {
        public int CurrentPage { get; private set; }
        public int TotalPages { get; private set; }
        public int PageSize { get; private set; }
        public int TotalCount { get; private set; }

        public bool HasPrev => CurrentPage > 1;
        public bool HasNext => CurrentPage < TotalPages;
        
        public PagedList(List<T> items, int totalCount, int pageNumber, int pageSize)
        {
            TotalCount = totalCount;
            PageSize = pageSize;
            CurrentPage = pageNumber;
            TotalPages = (int) Math.Ceiling(totalCount / (double) pageSize);
 
            AddRange(items);
        }

        public static async Task<PagedList<T>> Paginate(IQueryable<T> src, int pageNumber, int pageSize)
        {
            var count = src.Count();
            var items = await src.Skip((pageNumber - 1) * pageSize)
                .Take(pageSize).ToListAsync();
            return new PagedList<T>(items, count, pageNumber, pageSize);
        }
    }
}