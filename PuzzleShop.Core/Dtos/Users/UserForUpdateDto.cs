// ReSharper disable All
using System.ComponentModel.DataAnnotations;

namespace PuzzleShop.Core.Dtos.Users
{
    public class UserForUpdateDto
    {
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [MinLength(8, ErrorMessage ="Password must contain not less than 8 characters.")]
        public string Password { get; set; }
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }
        public string Address { get; set; }
        [Phone(ErrorMessage = "Invalid phone number.")]
        public string Phone { get; set; }
    }
}