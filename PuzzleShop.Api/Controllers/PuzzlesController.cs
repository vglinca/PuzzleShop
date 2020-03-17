using System;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PuzzleShop.Core;
using PuzzleShop.Domain.Entities;

namespace PuzzleShop.Api.Controllers
{
    [ApiController]
    [Route("api/puzzles")]
    public class PuzzlesController : ControllerBase
    {
        private readonly IRepository<Puzzle> _puzzleRepository;
        private readonly IMapper _mapper;

        public PuzzlesController(IRepository<Puzzle> puzzleRepository, IMapper mapper)
        {
            _puzzleRepository = puzzleRepository ?? throw new ArgumentNullException(nameof(puzzleRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        
        
    }
}