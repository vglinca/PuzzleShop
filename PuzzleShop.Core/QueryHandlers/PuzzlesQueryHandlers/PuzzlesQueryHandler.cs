using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using PuzzleShop.Core.Dtos.Puzzles;
using PuzzleShop.Core.PaginationModels;
using PuzzleShop.Core.Queries.Puzzles;
using PuzzleShop.Core.Repository.Interfaces;

namespace PuzzleShop.Core.QueryHandlers.PuzzlesQueryHandlers
{
    public class PuzzlesQueryHandler : 
        IRequestHandler<GetPuzzlesPagedQuery, PagedResponse<PuzzleTableRowDto>>,
        IRequestHandler<GetPuzzleQuery, PuzzleDto>,
        IRequestHandler<GetFriendlyPuzzleQuery, PuzzleTableRowDto>
    {
        private readonly IPuzzleRepository _puzzleRepository;
        private readonly IMapper _mapper;

        public PuzzlesQueryHandler(IPuzzleRepository puzzleRepository, IMapper mapper)
        {
            _puzzleRepository = puzzleRepository;
            _mapper = mapper;
        }

        public async Task<PagedResponse<PuzzleTableRowDto>> Handle(GetPuzzlesPagedQuery request, CancellationToken cancellationToken)
        {
            var puzzlesPaged = await _puzzleRepository.GetAllAsync(request.PagedRequest, _mapper);
            return puzzlesPaged;
        }

        public async Task<PuzzleDto> Handle(GetPuzzleQuery request, CancellationToken cancellationToken)
        {
            var puzzle = await _puzzleRepository.FindByIdAsync(request.Id);
            return _mapper.Map<PuzzleDto>(puzzle);
        }

        public async Task<PuzzleTableRowDto> Handle(GetFriendlyPuzzleQuery request, CancellationToken cancellationToken)
        {
            var puzzle = await _puzzleRepository.FindByIdAsync(request.Id);
            return _mapper.Map<PuzzleTableRowDto>(puzzle);
        }
    }
}