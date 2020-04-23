using System.ComponentModel.DataAnnotations;

namespace PuzzleShop.Core.Dtos.Users
{
    public class UserForAuthDto
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}