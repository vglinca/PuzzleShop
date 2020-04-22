using System.Threading.Tasks;
using PuzzleShop.Api.Helpers;
using PuzzleShop.Core.Dtos.Users;

namespace PuzzleShop.Api.Services.Interfaces
{
    public interface ISigningInService
    {
        Task<string> SignIn(AuthOptions authOptions, UserForAuthDto user);
    }
}