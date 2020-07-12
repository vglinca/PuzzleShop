using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using PuzzleShop.Core.Commands.Puzzles;
using PuzzleShop.Core.Repository.Interfaces;

namespace PuzzleShop.Core.CommandHandlers.PuzzlesCommandHandlers
{
    public class UpdatePuzzleCommandHandler : IRequestHandler<UpdatePuzzleCommand, Unit>
    {
        private readonly IPuzzleRepository _puzzleRepository;
        private readonly IMapper _mapper;

        public UpdatePuzzleCommandHandler(IPuzzleRepository puzzleRepository, IMapper mapper)
        {
            _puzzleRepository = puzzleRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdatePuzzleCommand request, CancellationToken cancellationToken)
        {
            var puzzleToEdit = await _puzzleRepository.FindByIdAsync(request.PuzzleId);
            _mapper.Map(request, puzzleToEdit);
            await _puzzleRepository.UpdateEntityAsync(puzzleToEdit);
            return Unit.Value;
        }
    }
}