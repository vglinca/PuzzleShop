namespace PuzzleShop.Core.ResourceParameters
{
    public class PuzzleResourceParameters
    {
        private const int maxPageSize = 20;
        public string FilterQuery { get; set; }
        public string OrderQuery { get; set; }
        public int PageNumber { get; set; } = 1;
        private int _pageSize = 10;

        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > maxPageSize) ? maxPageSize : value;
        }
    }
}