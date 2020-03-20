using System.ComponentModel.DataAnnotations;

namespace PuzzleShop.Api.Dtos.Users
{
    public class UserForAuthDto
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}