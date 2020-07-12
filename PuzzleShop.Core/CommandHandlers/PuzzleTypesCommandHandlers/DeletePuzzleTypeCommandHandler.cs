using System.Threading;
using System.Threading.Tasks;
using MediatR;
using PuzzleShop.Core.Commands.PuzzleTypes;
using PuzzleShop.Core.Entities;

namespace PuzzleShop.Core.CommandHandlers.PuzzleTypesCommandHandlers
{
    public class DeletePuzzleTypeCommandHandler : IRequestHandler<DeletePuzzleTypeCommand, Unit>
    {
        private readonly IRepository<PuzzleType> _puzzleTypeRepository;

        public DeletePuzzleTypeCommandHandler(IRepository<PuzzleType> puzzleTypeRepository)
        {
            _puzzleTypeRepository = puzzleTypeRepository;
        }

        public async Task<Unit> Handle(DeletePuzzleTypeCommand request, CancellationToken cancellationToken)
        {
            var puzzleType = await _puzzleTypeRepository.FindByIdAsync(request.Id);
            await _puzzleTypeRepository.DeleteEntityAsync(puzzleType);
            return Unit.Value;
        }
    }
}