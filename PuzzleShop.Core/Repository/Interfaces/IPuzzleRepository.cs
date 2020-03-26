using System.Threading.Tasks;
using AutoMapper;
using PuzzleShop.Core.Dtos.Puzzles;
using PuzzleShop.Core.PaginationModels;
using PuzzleShop.Domain.Entities;

namespace PuzzleShop.Core.Repository.Interfaces
{
    public interface IPuzzleRepository : IEfCoreRepository<Puzzle>
    {
        Task<PagedResponse<PuzzleDto>> GetAllAsync(PagedRequest pagedRequest, IMapper mapper);
    }
}