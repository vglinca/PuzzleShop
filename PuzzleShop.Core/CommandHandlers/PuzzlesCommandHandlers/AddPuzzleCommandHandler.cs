using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using PuzzleShop.Core.Commands.Puzzles;
using PuzzleShop.Core.Dtos.Puzzles;
using PuzzleShop.Core.Entities;
using PuzzleShop.Core.Repository.Interfaces;

namespace PuzzleShop.Core.CommandHandlers.PuzzlesCommandHandlers
{
    public class AddPuzzleCommandHandler : 
        IRequestHandler<AddPuzzleCommand, PuzzleDto>
    {
        private readonly IPuzzleRepository _puzzleRepository;
        private readonly IMapper _mapper;
        private readonly IHostingEnvironment _env;

        public AddPuzzleCommandHandler(IPuzzleRepository puzzleRepository, IMapper mapper, IHostingEnvironment env)
        {
            _puzzleRepository = puzzleRepository;
            _mapper = mapper;
            _env = env;
        }

        public async Task<PuzzleDto> Handle(AddPuzzleCommand request, CancellationToken cancellationToken)
        {
            var entityToAdd = _mapper.Map<Puzzle>(request);
            entityToAdd.Images = new List<Image>();
            var webRootPath = _env.WebRootPath;
            var i = 1;
            foreach (var img in request.Images)
            {
                var fileName = Guid.NewGuid() + ".jpg";
                var filePath = Path.Combine($"{webRootPath}/images/{fileName}");
                entityToAdd.Images.Add(new Image { FileName = fileName, Title = $"{entityToAdd.Name}-img{i++}" });
                await using var fStream = new FileStream(filePath, FileMode.Create);
                await img.CopyToAsync(fStream, cancellationToken);
            }
            await _puzzleRepository.AddEntityAsync(entityToAdd);
            var model = _mapper.Map<PuzzleDto>(entityToAdd);
            return model;
        }
    }
}