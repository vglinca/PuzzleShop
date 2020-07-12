using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using PuzzleShop.Core.Dtos.Colors;
using PuzzleShop.Core.Entities;
using PuzzleShop.Core.Queries.Colors;

namespace PuzzleShop.Core.QueryHandlers.ColorsQueryHandlers
{
    public class GetSingleColorQueryHandler : IRequestHandler<GetSingleColorQuery, ColorDto>
    {
        private readonly IRepository<Color> _colorRepository;
        private readonly IMapper _mapper;

        public GetSingleColorQueryHandler(IRepository<Color> colorRepository, IMapper mapper)
        {
            _colorRepository = colorRepository;
            _mapper = mapper;
        }
        public async Task<ColorDto> Handle(GetSingleColorQuery request, CancellationToken cancellationToken)
        {
            var color = await _colorRepository.FindByIdAsync((request.Id));
            return _mapper.Map<ColorDto>(color);
        }
    }
}