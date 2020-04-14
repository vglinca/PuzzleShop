// ReSharper disable All
namespace PuzzleShop.Core.PaginationModels
{
    public class PagedRequest
    {
        public string OrderBy { get; set; }
        public string OrderByDirection { get; set; } = "asc";
        private int _pageNumber = 1;
        public int PageNumber 
        { 
            get => _pageNumber;
            set => _pageNumber = (value < 1) ? _pageNumber : value;
        }
        public int PageSize { get; set; }
        public RequestFilters RequestFilters { get; set; }

        public PagedRequest()
        {
            RequestFilters = new RequestFilters();
        }
    }
}