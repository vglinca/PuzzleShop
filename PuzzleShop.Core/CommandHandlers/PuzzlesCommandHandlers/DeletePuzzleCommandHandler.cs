using System.IO;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using PuzzleShop.Core.Commands.Puzzles;
using PuzzleShop.Core.Repository.Interfaces;

namespace PuzzleShop.Core.CommandHandlers.PuzzlesCommandHandlers
{
    public class DeletePuzzleCommandHandler : IRequestHandler<DeletePuzzleCommand, Unit>
    {
        private readonly IPuzzleRepository _puzzleRepository;
        private readonly IImageRepository _imageRepository;
        private readonly IHostingEnvironment _env;

        public DeletePuzzleCommandHandler(IPuzzleRepository puzzleRepository, IImageRepository imageRepository, IHostingEnvironment env)
        {
            _puzzleRepository = puzzleRepository;
            _imageRepository = imageRepository;
            _env = env;
        }

        public async Task<Unit> Handle(DeletePuzzleCommand request, CancellationToken cancellationToken)
        {
            var images = await _imageRepository.GetImagesAsync(request.Id);
            var webRootPath = _env.WebRootPath;
            foreach (var img in images)
            {
                var filePath = Path.Combine($"{webRootPath}/images/{img.FileName}");
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
            }
            var puzzleToDelete = await _puzzleRepository.FindByIdAsync(request.Id);
            await _puzzleRepository.DeleteEntityAsync(puzzleToDelete);
            return Unit.Value;
        }
    }
}