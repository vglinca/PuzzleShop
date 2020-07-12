using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using PuzzleShop.Core.Commands.Reviews;
using PuzzleShop.Core.Dtos.Reviews;
using PuzzleShop.Core.Entities;
using PuzzleShop.Core.Exceptions;
using PuzzleShop.Core.Repository.Interfaces;

namespace PuzzleShop.Core.CommandHandlers.ReviewsCommandHandlers
{
    public class AddReviewCommandHandler : IRequestHandler<AddReviewCommand, ReviewDto>
    {
        private readonly IMapper _mapper;
        private readonly IPuzzleRepository _puzzleRepository;

        public AddReviewCommandHandler(IMapper mapper, IPuzzleRepository puzzleRepository)
        {
            _mapper = mapper;
            _puzzleRepository = puzzleRepository;
        }

        public async Task<ReviewDto> Handle(AddReviewCommand request, CancellationToken cancellationToken)
        {
            var puzzle = await _puzzleRepository.FindByIdAsync(request.PuzzleId);
            if (puzzle == null)
            {
                throw EntityNotFoundException.OfType<Puzzle>(request.PuzzleId);
            }
            var reviewEntity = _mapper.Map<Review>(request);
            puzzle.Reviews.Add(reviewEntity);
            var rating = puzzle.Reviews.Average(r => r.Rating);
            puzzle.Rating = rating;
            await _puzzleRepository.UpdateEntityAsync(puzzle);
            return _mapper.Map<ReviewDto>(reviewEntity);
        }
    }
}