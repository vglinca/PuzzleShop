using System.Threading.Tasks;
using PuzzleShop.Api.Helpers;

namespace PuzzleShop.Api.Services.Interfaces
{
    public interface ISigningInService
    {
        Task<string> SignIn(AuthOptions authOptions, string userName);
    }
}