using System.ComponentModel.DataAnnotations;

namespace PuzzleShop.Api.Models.Reviews
{
    public class ReviewCreateModel
    {
        [Required]
        public string ReviewerName { get; set; }
        [EmailAddress]
        public string ReviewerEmail { get; set; }
        public double? Rating { get; set; }
        [MaxLength(100)]
        public string ReviewTitle { get; set; }
        [MaxLength(1500)]
        public string ReviewBody { get; set; }
    }
}