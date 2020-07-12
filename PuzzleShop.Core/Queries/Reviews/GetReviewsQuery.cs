using System.Collections.Generic;
using MediatR;
using PuzzleShop.Core.Dtos.Reviews;

namespace PuzzleShop.Core.Queries.Reviews
{
    public class GetReviewsQuery : IRequest<IEnumerable<ReviewDto>>
    {
        public long PuzzleId { get; set; }
    }
}