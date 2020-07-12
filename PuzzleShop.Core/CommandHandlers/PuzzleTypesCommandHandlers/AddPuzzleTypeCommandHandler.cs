using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using PuzzleShop.Core.Commands.PuzzleTypes;
using PuzzleShop.Core.Dtos.PuzzleTypes;
using PuzzleShop.Core.Entities;

namespace PuzzleShop.Core.CommandHandlers.PuzzleTypesCommandHandlers
{
    public class AddPuzzleTypeCommandHandler : IRequestHandler<AddPuzzleTypeCommand, PuzzleTypeDto>
    {
        private readonly IRepository<PuzzleType> _puzzleTypeRepository;
        private readonly IMapper _mapper;

        public AddPuzzleTypeCommandHandler(IRepository<PuzzleType> puzzleTypeRepository, IMapper mapper)
        {
            _puzzleTypeRepository = puzzleTypeRepository;
            _mapper = mapper;
        }

        public async Task<PuzzleTypeDto> Handle(AddPuzzleTypeCommand request, CancellationToken cancellationToken)
        {
            var puzzleType = _mapper.Map<PuzzleType>(request);
            await _puzzleTypeRepository.AddEntityAsync(puzzleType);
            return _mapper.Map<PuzzleTypeDto>(puzzleType);
        }
    }
}