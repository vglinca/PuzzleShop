using MediatR;
using PuzzleShop.Core.Dtos.Reviews;

namespace PuzzleShop.Core.Commands.Reviews
{
    public class AddReviewCommand : IRequest<ReviewDto>
    {
        public long PuzzleId { get; set; }
        public string ReviewerName { get; set; }
        public string ReviewerEmail { get; set; }
        public double? Rating { get; set; }
        public string ReviewTitle { get; set; }
        public string ReviewBody { get; set; }
    }
}