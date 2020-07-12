using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using PuzzleShop.Core.Commands.Images;
using PuzzleShop.Core.Repository.Interfaces;

namespace PuzzleShop.Core.CommandHandlers.ImagesCommandHandlers
{
    public class DeleteImagesCommandHandler : IRequestHandler<DeleteImagesCommand, Unit>
    {
        private readonly IImageRepository _imagesRepository;
        private readonly IHostingEnvironment _env;

        public DeleteImagesCommandHandler(IImageRepository imagesRepository, IHostingEnvironment env)
        {
            _imagesRepository = imagesRepository;
            _env = env;
        }

        public async Task<Unit> Handle(DeleteImagesCommand request, CancellationToken cancellationToken)
        {
            var images = await _imagesRepository.GetImagesAsync(request.PuzzleId);
            var webRootPath = _env.WebRootPath;
            foreach (var img in images)
            {
                var filePath = Path.Combine($"{webRootPath}/images/{img.FileName}");
                if (File.Exists(filePath) && request.ImageIds.Contains(img.Id))
                {
                    File.Delete(filePath);
                }
            }
            await _imagesRepository.DeleteImagesAsync(request.PuzzleId, request.ImageIds);
            return Unit.Value;
        }
    }
}