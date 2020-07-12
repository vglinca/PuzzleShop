using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using PuzzleShop.Core.Dtos.Manufacturers;
using PuzzleShop.Core.Entities;
using PuzzleShop.Core.Queries.Manufacturers;

namespace PuzzleShop.Core.QueryHandlers.ManufacturersQueryHandlers
{
    public class ManufacturersQueryHandler : 
        IRequestHandler<GetManufacturersQuery, IEnumerable<ManufacturerDto>>,
        IRequestHandler<GetManufacturerQuery, ManufacturerDto>
    {
        private readonly IRepository<Manufacturer> _manufacturersRepository;
        private readonly IMapper _mapper;

        public ManufacturersQueryHandler(IRepository<Manufacturer> manufacturersRepository, IMapper mapper)
        {
            _manufacturersRepository = manufacturersRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ManufacturerDto>> Handle(GetManufacturersQuery request, CancellationToken cancellationToken)
        {
            var manufacturers = await _manufacturersRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ManufacturerDto>>(manufacturers);
        }

        public async Task<ManufacturerDto> Handle(GetManufacturerQuery request, CancellationToken cancellationToken)
        {
            var manufacturer = await _manufacturersRepository.FindByIdAsync(request.Id);
            return _mapper.Map<ManufacturerDto>(manufacturer);
        }
    }
}