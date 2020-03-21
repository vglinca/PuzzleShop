using System;
using System.ComponentModel.DataAnnotations;
// ReSharper disable All

namespace PuzzleShop.Api.Dtos.Users
{
    public class UserForRegistrationDto
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [MinLength(8, ErrorMessage = "Password should not be less than 8 characters.")]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public DateTimeOffset BirthDate { get; set; }
        public string PhoneNumber { get; set; }
    }
}