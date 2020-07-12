using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using PuzzleShop.Core.Dtos.Images;
using PuzzleShop.Core.Queries.Images;
using PuzzleShop.Core.Repository.Interfaces;

namespace PuzzleShop.Core.QueryHandlers.ImagesQueryHandlers
{
    public class GetImagesQueryHandler : IRequestHandler<GetImagesQuery, IEnumerable<ImageDto>>
    {
        private readonly IImageRepository _imagesRepository;
        private readonly IMapper _mapper;
        
        public GetImagesQueryHandler(IImageRepository repository, IMapper mapper)
        {
            _imagesRepository = repository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ImageDto>> Handle(GetImagesQuery request, CancellationToken cancellationToken)
        {
            var images = await _imagesRepository.GetImagesAsync(request.PuzzleId);
            var models = _mapper.Map<IEnumerable<ImageDto>>(images);
            return models;
        }
    }
}