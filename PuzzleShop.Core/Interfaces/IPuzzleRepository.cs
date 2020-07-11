using System.Threading.Tasks;
using AutoMapper;
using PuzzleShop.Core.Dtos.Puzzles;
using PuzzleShop.Core.Entities;
using PuzzleShop.Core.Interfaces;
using PuzzleShop.Core.PaginationModels;

namespace PuzzleShop.Core.Repository.Interfaces
{
    public interface IPuzzleRepository : IEfCoreRepository<Puzzle>
    {
        Task<PagedResponse<PuzzleTableRowDto>> GetAllAsync(PagedRequest pagedRequest, IMapper mapper);
    }
}