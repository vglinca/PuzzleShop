using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using PuzzleShop.Core.Commands.Manufacturers;
using PuzzleShop.Core.Dtos.Manufacturers;
using PuzzleShop.Core.Entities;

namespace PuzzleShop.Core.CommandHandlers.ManufacturersCommandHandlers
{
    public class ManufacturerCommandHandler : 
        IRequestHandler<AddManufacturerCommand, ManufacturerDto>,
        IRequestHandler<UpdateManufacturerCommand, Unit>,
        IRequestHandler<DeleteManufacturerCommand, Unit>
    {
        private readonly IRepository<Manufacturer> _manufacturersRepository;
        private readonly IMapper _mapper;

        public ManufacturerCommandHandler(IRepository<Manufacturer> manufacturersRepository, IMapper mapper)
        {
            _manufacturersRepository = manufacturersRepository;
            _mapper = mapper;
        }

        public async Task<ManufacturerDto> Handle(AddManufacturerCommand request, CancellationToken cancellationToken)
        {
            var manufacturer = _mapper.Map<Manufacturer>(request);
            var createdEntity = await _manufacturersRepository.AddEntityAsync(manufacturer);
            return _mapper.Map<ManufacturerDto>(createdEntity);
        }

        public async Task<Unit> Handle(UpdateManufacturerCommand request, CancellationToken cancellationToken)
        {
            var manufacturer = await _manufacturersRepository.FindByIdAsync(request.Id);
            _mapper.Map(request, manufacturer);
            await _manufacturersRepository.UpdateEntityAsync(manufacturer);
            return Unit.Value;
        }

        public async Task<Unit> Handle(DeleteManufacturerCommand request, CancellationToken cancellationToken)
        {
            var manufacturer = await _manufacturersRepository.FindByIdAsync(request.Id);
            await _manufacturersRepository.DeleteEntityAsync(manufacturer);
            return Unit.Value;
        }
    }
}