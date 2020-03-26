// ReSharper disable All
namespace PuzzleShop.Core.PaginationModels
{
    public class PagedRequest
    {
        public string OrderBy { get; set; }
        public string OrderByDirection { get; set; } = "asc";
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public RequestFilters RequestFilters { get; set; }

        public PagedRequest()
        {
            RequestFilters = new RequestFilters();
        }
    }
}