using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using PuzzleShop.Core.Dtos.PuzzleTypes;
using PuzzleShop.Core.Entities;
using PuzzleShop.Core.Queries.PuzzleTypes;

namespace PuzzleShop.Core.QueryHandlers.PuzzleTypesQueryHandlers
{
    public class PuzzleTypesQueryHandler : 
        IRequestHandler<GetPuzzleTypesQuery, IEnumerable<PuzzleTypeTableRowDto>>,
        IRequestHandler<GetPuzzleTypeQuery, PuzzleTypeDto>,
        IRequestHandler<GetFriendlyPuzzleTypeQuery, PuzzleTypeTableRowDto>
    {
        private readonly IRepository<PuzzleType> _puzzleTypeRepository;
        private readonly IMapper _mapper;

        public PuzzleTypesQueryHandler(IRepository<PuzzleType> puzzleTypeRepository, IMapper mapper)
        {
            _puzzleTypeRepository = puzzleTypeRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PuzzleTypeTableRowDto>> Handle(GetPuzzleTypesQuery request, CancellationToken cancellationToken)
        {
            var puzzleTypeEntities = await _puzzleTypeRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<PuzzleTypeTableRowDto>>(puzzleTypeEntities);
        }

        public async Task<PuzzleTypeDto> Handle(GetPuzzleTypeQuery request, CancellationToken cancellationToken)
        {
            var puzzleType = await _puzzleTypeRepository.FindByIdAsync(request.Id);
            return _mapper.Map<PuzzleTypeDto>(puzzleType);
        }

        public async Task<PuzzleTypeTableRowDto> Handle(GetFriendlyPuzzleTypeQuery request, CancellationToken cancellationToken)
        {
            var puzzleType = await _puzzleTypeRepository.FindByIdAsync(request.Id);
            return _mapper.Map<PuzzleTypeTableRowDto>(puzzleType);
        }
    }
}