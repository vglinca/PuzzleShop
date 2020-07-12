using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore.Internal;
using PuzzleShop.Core.Commands.Images;
using PuzzleShop.Core.Entities;
using PuzzleShop.Core.Repository.Interfaces;

namespace PuzzleShop.Core.CommandHandlers.ImagesCommandHandlers
{
    public class AddImageCommandHandler : IRequestHandler<AddImageCommand, Unit>
    {
        private readonly IImageRepository _imagesRepository;
        private readonly IHostingEnvironment _env;

        public AddImageCommandHandler(IImageRepository imagesRepository, IHostingEnvironment env)
        {
            _imagesRepository = imagesRepository;
            _env = env;
        }

        public async Task<Unit> Handle(AddImageCommand request, CancellationToken cancellationToken)
        {
            var webRootPath = _env.WebRootPath;
            var imagesToAdd = new List<Image>();
            if (request.Id == null || request.Id <= 0)
            {
                var fileName = Guid.NewGuid() + ".jpg";
                var filePath = Path.Combine($"{webRootPath}/images/{fileName}");
                imagesToAdd.Add(new Image { FileName = fileName, PuzzleId = request.PuzzleId, Title = request.Title });
                await using var fStream = new FileStream(filePath, FileMode.Create);
                await request.File.CopyToAsync(fStream, cancellationToken);
            }
            if (imagesToAdd.Any())
            {
                await _imagesRepository.AddImagesAsync(imagesToAdd);
            }
            return Unit.Value;
        }
    }
}