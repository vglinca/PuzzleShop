using System;
using System.ComponentModel.DataAnnotations;
// ReSharper disable All

namespace PuzzleShop.Core.Dtos.Users
{
    public class UserForRegistrationDto
    {
        [Required(ErrorMessage = "FirstName is required.")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "LastName is required.")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Password is required.")]
        [MinLength(8, ErrorMessage = "Password should not be less than 8 characters.")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "BirthDate is required.")]
        public DateTimeOffset BirthDate { get; set; }
     
    }
}