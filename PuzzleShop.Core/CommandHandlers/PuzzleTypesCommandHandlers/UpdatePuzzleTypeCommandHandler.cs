using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using PuzzleShop.Core.Commands.PuzzleTypes;
using PuzzleShop.Core.Entities;

namespace PuzzleShop.Core.CommandHandlers.PuzzleTypesCommandHandlers
{
    public class UpdatePuzzleTypeCommandHandler : IRequestHandler<UpdatePuzzleTypeCommand, Unit>
    {
        private readonly IRepository<PuzzleType> _puzzleTypeRepository;
        private readonly IMapper _mapper;

        public UpdatePuzzleTypeCommandHandler(IRepository<PuzzleType> puzzleTypeRepository, IMapper mapper)
        {
            _puzzleTypeRepository = puzzleTypeRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdatePuzzleTypeCommand request, CancellationToken cancellationToken)
        {
            var puzzleType = await _puzzleTypeRepository.FindByIdAsync(request.PuzzleTypeId);
            _mapper.Map(request, puzzleType);
            await _puzzleTypeRepository.UpdateEntityAsync(puzzleType);
            return Unit.Value;
        }
    }
}