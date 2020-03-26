using System.Collections.Generic;
// ReSharper disable All

namespace PuzzleShop.Core.PaginationModels
{
    public class RequestFilters
    {
        public LogicalOperator Operator { get; set; }
        public List<Filter> Filters { get; set; }

        public RequestFilters()
        {
            Filters = new List<Filter>();
        }
    }
}