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
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public DateTimeOffset BirthDate { get; set; }
        public string Phone { get; set; }
        [Required]
        public long UserRoleId { get; set; }
    }
}