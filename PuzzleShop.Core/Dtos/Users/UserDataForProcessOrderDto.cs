using System.ComponentModel.DataAnnotations;

namespace PuzzleShop.Core.Dtos.Users
{
    public class UserDataForProcessOrderDto
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }
        public string PostalIndex { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
    }
}