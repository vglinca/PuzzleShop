// ReSharper disable All

using System;
using System.Collections.Generic;

namespace PuzzleShop.Core.PaginationModels
{
    public class PagedResponse<T> where T : class
    {
        public int CurrentPage { get; set; }
        public int TotalPages { get; private set; }
        public int PageSize { get; set; }
        public int TotalItems { get; set; }

        public bool HasPrev => CurrentPage > 1;
        public bool HasNext => CurrentPage < TotalPages;
        public IList<T> Items { get; set; }

        public PagedResponse(int currentPage, int pageSize, int totalItems, IList<T> items)
        {
            CurrentPage = currentPage;
            PageSize = pageSize;
            TotalPages = (int) Math.Ceiling(totalItems / (double) pageSize);
            TotalItems = totalItems;
            Items = items;
        }
    }
}