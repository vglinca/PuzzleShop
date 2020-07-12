using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using PuzzleShop.Core.Dtos.Reviews;
using PuzzleShop.Core.Entities;
using PuzzleShop.Core.Exceptions;
using PuzzleShop.Core.Queries.Reviews;
using PuzzleShop.Core.Repository.Interfaces;

namespace PuzzleShop.Core.QueryHandlers.ReviewsQueryHandlers
{
    public class GetReviewsQueryHandler : IRequestHandler<GetReviewsQuery, IEnumerable<ReviewDto>>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Review> _reviewRepository;
        private readonly IPuzzleRepository _puzzleRepository;

        public GetReviewsQueryHandler(IMapper mapper, IRepository<Review> reviewRepository, IPuzzleRepository puzzleRepository)
        {
            _mapper = mapper;
            _reviewRepository = reviewRepository;
            _puzzleRepository = puzzleRepository;
        }

        public async Task<IEnumerable<ReviewDto>> Handle(GetReviewsQuery request, CancellationToken cancellationToken)
        {
            var puzzle = await _puzzleRepository.FindByIdAsync(request.PuzzleId);
            if(puzzle == null)
            {
                throw EntityNotFoundException.OfType<Puzzle>(request.PuzzleId);
            }
            var reviews = await _reviewRepository.GetAllAsync(review => review.PuzzleId == request.PuzzleId);
            var models = _mapper.Map<IEnumerable<ReviewDto>>(reviews);
            return models;
        }
    }
}